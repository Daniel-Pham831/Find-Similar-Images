using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNToolWF
{
    public class FileItem
    {
        public string name { get; set; }
        public string path { get; set; }
        public string sizeInKiloByte { 
            get
            {
                return $"{size / 1024} KB";
            } 
        }

        public FileItem(string fullPath)
        {
            name = Path.GetFileName(fullPath);
            path = fullPath;
            size = new FileInfo(fullPath).Length;
        }

        public long size { get; set; }

        public static List<string> GetAllPaths(List<FileItem> fileItems)
        {
            List<string> paths = new List<string>();

            foreach (var item in fileItems)
            {
                paths.Add(item.path);
            }

            return paths;
        }
    }
}
