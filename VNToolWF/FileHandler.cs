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
        private readonly float marginOfErrorInPercentage = 0.08f;
        private readonly int maximumRunningThread = 10;
        private string folderPath = "";
        private List<Thread> threads;
        public List<FileItem> DuplicatedItems;
        public Queue<int> DuplicatedGroups;
        public List<FileItem> SimilarImages;

        public Action OnFindAllDuplicatedFinished;
        public Action OnFindAllSimilarFinished;

        public FileHandler()
        {
            threads = new List<Thread>(maximumRunningThread);
        }

        public void ProcessFolder(string folderPath = "")
        {
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

        private void ProcessSimilarImages(List<string> filePaths)
        {
            SimilarImages = new List<FileItem>();

            ProcessSimilarImagesMethod(filePaths);
            OnFindAllSimilarFinished?.Invoke();


            //List<List<List<string>>> pathsForMultiThreading = ProcessSameRatioImages(filePaths);

            //foreach (var multiPaths in pathsForMultiThreading)
            //{
            //    threads.Add(new Thread(() =>
            //    {
            //            ThreadProcessSimilarImages(multiPaths);
            //            OnFindAllSimilarFinished?.Invoke();
            //    }));
            //}

            //RunAllThread();
        }

        private List<List<List<string>>> ProcessSameRatioImages(List<string> filePaths)
        {
            Dictionary<float, List<string>> sameRatioImages = new Dictionary<float, List<string>>();

            foreach (var path in filePaths)
            {
                using (Image img = Image.FromFile(path))
                {
                    float ratio = (float)Math.Round(img.Width * 1.0f / img.Height, 2);

                    if (!sameRatioImages.ContainsKey(ratio))
                    {
                        sameRatioImages[ratio] = new List<string>();
                    }

                    sameRatioImages[ratio].Add(path);
                }
            }

            List<List<List<string>>> pathsForMultiThreading = new List<List<List<string>>>();
            int counter = 0;
            foreach (var paths in sameRatioImages.Values)
            {
                if (paths.Count > 1)
                {
                    if(pathsForMultiThreading.Count < maximumRunningThread)
                        pathsForMultiThreading.Add(new List<List<string>>());

                    pathsForMultiThreading[counter].Add(paths);

                    counter = (counter + 1) % maximumRunningThread;
                }
            }

            return pathsForMultiThreading;
        }

        private void RunAllThread()
        {
            foreach (var thread in threads)
            {
                thread?.Start();
            }
        }

        private void ThreadProcessSimilarImages(List<List<string>> multiPaths)
        {
            foreach (var paths in multiPaths)
            {
                ProcessSimilarImagesMethod(paths);
            }
        }

        private void ProcessSimilarImagesMethod(List<string> filePaths)
        {
            for (int i = 0; i < filePaths.Count - 1; i++)
            {
                for (int j = i + 1; j < filePaths.Count; j++)
                {
                    if (ImageHandler.IsSameRatioWithMarginOfError(filePaths[i], filePaths[j], marginOfErrorInPercentage))
                    {
                        // Find which imageIndex is smaller
                        int bigImgIndex = ImageHandler.IsABiggerThanB(filePaths[i], filePaths[j]) ? i : j;
                        int smallImgIndex = ImageHandler.IsABiggerThanB(filePaths[i], filePaths[j]) ? j : i;

                        string resizedImagePath = ImageHandler.ResizeWithMagick(filePaths[bigImgIndex], filePaths[smallImgIndex]);
                        double result = ImageHandler.CompareWithMagick(resizedImagePath, filePaths[smallImgIndex]);
                        bool areTheySimilar = result / ImageHandler.GetTotalPixel(resizedImagePath) <= marginOfErrorInPercentage;

                        if (areTheySimilar)
                        {
                            SimilarImages.Add(new FileItem(filePaths[i]));
                            SimilarImages.Add(new FileItem(filePaths[j]));
                        }

                        // Delete the resizedImage
                        File.Delete(resizedImagePath);
                    }
                }
            }
        }
    }
}
