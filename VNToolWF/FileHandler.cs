using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VNToolWF
{
    public class FileHandler
    {
        private readonly string processType = "*.png";
        private string folderPath = "";
        public List<FileItem> DuplicatedItems;
        public Queue<int> DuplicatedGroups;
        public List<FileItem> SimilarImages;
        

        public Action OnFindAllDuplicatedFinished;
        public Action OnNewSimilarAdded;
        public Action OnFindAllSimilarFinished;

        private List<Task<bool>> tasks;

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
            DuplicatedGroups = new Queue<int>();
            Dictionary<string, List<string>> duplicatedNames = ConvertAllFilesPathIntoDic(filePaths);
            FilterDuplicatedFilesName(duplicatedNames);

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
            foreach (string fileName in duplicatedNames.Keys)
            {
                // Only add if there are duplicated files
                if (duplicatedNames[fileName].Count > 1)
                {
                    DuplicatedGroups.Enqueue(duplicatedNames[fileName].Count);
                    foreach (string filePath in duplicatedNames[fileName])
                    {
                        DuplicatedItems.Add(new FileItem(filePath));
                    }
                }
            }
        }

        private async void ProcessSimilarImages(List<string> filePaths)
        {
            SimilarImages = new List<FileItem>();

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
                        SimilarImages.Add(new FileItem(filePaths[i]));
                        SimilarImages.Add(new FileItem(filePaths[j]));

                        OnNewSimilarAdded?.Invoke();
                    }
                }
            }
        }
    }
}
