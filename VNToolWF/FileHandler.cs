using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNToolWF
{
    public class FileHandler
    {
        private readonly string processType = "*.png";
        private string folderPath = "";
        private Dictionary<string ,List<string>> DuplicatedPaths;
        public List<FileItem> DuplicatedItems;
        
        public void ProcessFolder(string folderPath = "")
        {
            if(folderPath == "")
            {
                folderPath = this.folderPath;
            }
            else
            {
                this.folderPath = folderPath;
            }

            DuplicatedItems = new List<FileItem>();
            DuplicatedPaths = new Dictionary<string, List<string>>();
            
            ListFilesInDicrectory(folderPath, processType);
        }

        public List<string> GetFilePathsFromFileNames(string fileName)
        {
            return DuplicatedPaths[fileName];
        }

        public string GetFullPath(string shortenPath)
        {
            return folderPath + shortenPath;
        }

        private void ListFilesInDicrectory(string path, string type)
        {
            List<FileItem> filesInfo = new List<FileItem>();

            string[] filePaths = Directory.GetFiles(path, type, SearchOption.AllDirectories);
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                var reducedPath = $"{filePath.Replace(path, "")}";
                long size = new FileInfo(filePath).Length;

                filesInfo.Add(
                    new FileItem()
                    {
                        name = fileName,
                        path = reducedPath,
                        size = size
                    }
                );

                if (!DuplicatedPaths.ContainsKey(fileName))
                {
                    DuplicatedPaths[fileName] = new List<string>();
                }

                DuplicatedPaths[fileName].Add(filePath);
            }

            FindDuplicateFiles(filesInfo);
        }
        private void FindDuplicateFiles(List<FileItem> filesInfo)
        {
            Dictionary<string, List<string>> duplicateFilesName = new Dictionary<string, List<string>>();
            Dictionary<string, long> filesSize = new Dictionary<string, long>();

            foreach (FileItem fileInfo in filesInfo)
            {
                if (!duplicateFilesName.ContainsKey(fileInfo.name))
                {
                    duplicateFilesName[fileInfo.name] = new List<string>();
                }

                filesSize[fileInfo.path] = fileInfo.size;
                duplicateFilesName[fileInfo.name].Add(fileInfo.path);
            }

            foreach (string name in duplicateFilesName.Keys)
            {
                if (duplicateFilesName[name].Count > 1)
                {
                    string fileName = name;
                    foreach (string filePath in duplicateFilesName[name])
                    {
                        DuplicatedItems.Add(
                            new FileItem()
                            {
                                name = fileName,
                                path = filePath,
                                size = filesSize[filePath],
                                sizeInKiloByte = $"{filesSize[filePath] / 1024} KB"
                            }
                        );

                        fileName = "";
                    }
                }
            }
        }
    }
}
