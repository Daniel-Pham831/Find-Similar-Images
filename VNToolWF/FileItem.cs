using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNToolWF
{
    public class FileItem
    {
        public int groupIndex { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string sizeInKiloByte { 
            get
            {
                return $"{size / 1024} KB";
            } 
        }

        public string dimensions {
            get
            {
                string imgDimensions = "{0}x{1}";
                using (Image img = Image.FromFile(path))
                {
                    imgDimensions = String.Format(imgDimensions, img.Width, img.Height);
                }

                return imgDimensions;
            }
        }

        public Tuple<int,int> Dimensions
        {
            get
            {
                Tuple<int, int> imgDimensions;
                using (Image img = Image.FromFile(path))
                {
                    imgDimensions = new Tuple<int, int>(img.Width, img.Height);
                }

                return imgDimensions;
            }
        }

        public FileItem(string fullPath)
        {
            name = Path.GetFileName(fullPath);
            path = fullPath;
        }

        public long size { 
            get {
                return new FileInfo(path).Length;
            }
        }

        public static List<string> GetAllPaths(List<FileItem> fileItems)
        {
            List<string> paths = new List<string>();

            foreach (var item in fileItems)
            {
                paths.Add(item.path);
            }

            return paths;
        }

        public void Update()
        {

        }
    }
}
