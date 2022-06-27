using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNToolWF
{
    public class FileHandler
    {
        private readonly string processType = "*.png";
        private string folderPath = "";

        public List<FileItem> DuplicatedItems;
        public List<List<string>> DuplicatedGroups;

        public List<FileItem> SimilarImages;
        public List<List<string>> SimilarGroups;

        public Action OnFindAllDuplicatedFinished;
        public Action OnNewSimilarAdded;
        public Action OnFindAllSimilarFinished;

        private List<Task<bool>> tasks;

        public FileHandler()
        {
            if (!HasWinMergeAsEnvironmentVariable())
            {
                DialogResult dr = MessageBox.Show("Cannot find WinMerge. Please select the Winmerge application path.", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                    SetWinMergeEnvironmentVariable();
            }
        }

        private void SetWinMergeEnvironmentVariable()
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string path = dialog.FileName;
                    string fileName = Path.GetFileName(path);
                    if (fileName != CommandHandler.WinMerge)
                    {
                        MessageBox.Show("This is not WinMerge. Please goes here https://winmerge.org/ and install it", "Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Application.Exit();
                    }

                    path = $"{path.Replace("\\" + fileName, "")}";

                    var name = "PATH";
                    var scope = EnvironmentVariableTarget.User; // or User
                    var oldValue = Environment.GetEnvironmentVariable(name, scope);
                    Environment.SetEnvironmentVariable(name, oldValue + @";" + path, scope);
                }
            }
        }

        private bool HasWinMergeAsEnvironmentVariable()
        {
            string value = Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.User);

            return value.IndexOf("WinMerge") != -1;
        }

        public void ProcessFolder(string folderPath = "")
        {
            tasks = new List<Task<bool>>();
            if (folderPath != "")
            {
                this.folderPath = folderPath;
            }
            else
            {
                folderPath = this.folderPath;
            }
            List<string> filePaths = Directory.GetFiles(folderPath, processType, SearchOption.AllDirectories).ToList();

            ProcessDuplicateNames(filePaths);
            ProcessSimilarImages(RemoveDuplicateNames(filePaths));
        }

        private List<string> RemoveDuplicateNames(List<string> filePaths)
        {
            List<string> allDuplicatedNames = FileItem.GetAllPaths(DuplicatedItems);

            foreach (var path in allDuplicatedNames)
            {
                filePaths.Remove(path);
            }

            return filePaths;
        }

        private void ProcessDuplicateNames(List<string> filePaths)
        {
            DuplicatedItems = new List<FileItem>();
            DuplicatedGroups = new List<List<string>>();
            
            
            FilterDuplicatedFilesName(ConvertAllFilesPathIntoDic(filePaths));

            OnFindAllDuplicatedFinished?.Invoke();
        }
        private Dictionary<string, List<string>> ConvertAllFilesPathIntoDic(List<string> filePaths)
        {
            Dictionary<string, List<string>> duplicatedNames = new Dictionary<string, List<string>>();

            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);

                if (!duplicatedNames.ContainsKey(fileName))
                {
                    duplicatedNames[fileName] = new List<string>();
                }

                duplicatedNames[fileName].Add(filePath);
            }

            return duplicatedNames;
        }

        private void FilterDuplicatedFilesName(Dictionary<string, List<string>> duplicatedNames)
        {
            int groupCounter = 0;
            foreach (string fileName in duplicatedNames.Keys)
            {
                // Only add if there are duplicated files
                if (duplicatedNames[fileName].Count > 1)
                {
                    List<string> groupPaths = new List<string>();

                    foreach (string filePath in duplicatedNames[fileName])
                    {
                        groupPaths.Add(filePath);

                        FileItem newFileItem = new FileItem(filePath);
                        newFileItem.groupIndex = groupCounter;

                        DuplicatedItems.Add(newFileItem);
                    }

                    DuplicatedGroups.Add(groupPaths);
                    groupCounter++;
                }
            }
        }

        private async void ProcessSimilarImages(List<string> filePaths)
        {
            SimilarImages = new List<FileItem>();
            SimilarGroups = new List<List<string>>();
            ThreadProcessSimilarImages(GetSameRatioImages(filePaths));

            await AwaitAllTasks(tasks);
            OnFindAllSimilarFinished?.Invoke();
        }

        private async Task AwaitAllTasks(List<Task<bool>> tasks)
        {
            while (tasks.Count > 0)
            {
                var t = await Task.WhenAny(tasks);
                tasks.Remove(t);
            }
        }

        private List<List<string>> GetSameRatioImages(List<string> filePaths)
        {
            Dictionary<float, List<string>> sameRatioImagesDic = new Dictionary<float, List<string>>();

            foreach (var path in filePaths)
            {
                using (Image img = Image.FromFile(path))
                {
                    float ratio = (float)Math.Round(img.Width * 1.0f / img.Height, 2);

                    if (!sameRatioImagesDic.ContainsKey(ratio))
                    {
                        sameRatioImagesDic[ratio] = new List<string>();
                    }

                    sameRatioImagesDic[ratio].Add(path);
                }
            }

            List<List<string>> sameRatioImages = new List<List<string>>();
            foreach (var paths in sameRatioImagesDic.Values)
            {
                if (paths.Count > 1)
                {
                    sameRatioImages.Add(paths);
                }
            }

            return sameRatioImages;
        }

        private void ThreadProcessSimilarImages(List<List<string>> multiPaths)
        {
            foreach (var paths in multiPaths)
            {
                ProcessSimilarRatioImages(paths);
            }
        }

        private async void ProcessSimilarRatioImages(List<string> filePaths)
        {
            for (int i = 0; i < filePaths.Count - 1; i++)
            {
                for (int j = i + 1; j < filePaths.Count; j++)
                {
                    Task<bool> task = new Task<bool>(() => ImageHandler.AreTheySimilar(filePaths[i], filePaths[j]));
                    task.Start();
                    tasks.Add(task);

                    bool areTheySimilar = await task;

                    if (areTheySimilar)
                    {
                        List<string> similarPaths = new List<string>();
                        similarPaths.Add(filePaths[i]);
                        similarPaths.Add(filePaths[j]);
                        
                        foreach (var path in similarPaths)
                        {
                            FileItem newFileItem = new FileItem(path);
                            newFileItem.groupIndex = SimilarGroups.Count;
                            SimilarImages.Add(newFileItem);
                        }

                        SimilarGroups.Add(similarPaths);

                        OnNewSimilarAdded?.Invoke();
                    }
                }
            }
        }
    }
}
