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
        public List<FileItem> DuplicatedItems;

        public FileHandler()
        {
            DuplicatedItems = new List<FileItem>();
        }

        public void ProcessFolder(string folderPath)
        {

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
            }
        }
    }
}
