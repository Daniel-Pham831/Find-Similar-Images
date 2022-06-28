using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNToolWF
{
    public static class ImageHandler
    {
        private static readonly float marginOfErrorInPercentage = 0.08f;

        public static bool IsSameRatioWithMarginOfError(string pathImg1, string pathImg2, float marginOfError)
        {
            float img1Ratio;
            float img2Ratio;
            using (Image imgA = Image.FromFile(pathImg1))
            {
                img1Ratio = imgA.Width * 1.0f / imgA.Height;
            }
            using (Image imgB = Image.FromFile(pathImg2))
            {
                img2Ratio = imgB.Width * 1.0f / imgB.Height;
            }

            float bigNum = img1Ratio > img2Ratio ? img1Ratio : img2Ratio;
            return Math.Abs(img1Ratio - img2Ratio) / bigNum <= marginOfError;
        }

        public static double CompareWithMagick(string pathA, string pathB)
        {
            MagickImage imgA = new MagickImage(pathA);
            MagickImage imgB = new MagickImage(pathB);
            imgA.ColorFuzz = new Percentage(marginOfErrorInPercentage * 100);

            double diff = imgA.Compare(imgB, ErrorMetric.Absolute);

            imgA.Dispose();
            imgB.Dispose();

            return diff;
        }

        // resize the bigImg into the smallImg size
        // return the resized image path name: hashNowTime-(filename).png
        public static string ResizeWithMagick(string bigImgPath, string smallImgPath)
        {
            string prefix = DateTime.Now.GetHashCode().ToString() + "-";
            string fileName = Path.GetFileName(bigImgPath);
            string resizedImgPath = $"{bigImgPath.Replace(fileName, prefix + fileName)}";

            using (MagickImage image1 = new MagickImage(bigImgPath))
            {
                using (Image smallImg = Image.FromFile(smallImgPath))
                {
                    image1.Resize(smallImg.Width, smallImg.Height);
                    image1.Write(resizedImgPath);
                }
            }

            return resizedImgPath;
        }

        public static bool IsABiggerThanB(string pathImgA, string pathImgB)
        {
            bool result;
            using (Image imgA = Image.FromFile(pathImgA))
            using (Image imgB = Image.FromFile(pathImgB))
            {
                result = imgA.Width > imgB.Width;
            }

            return result;
        }

        public static float GetDifferInPercentage(string pathImgA, string pathImgB)
        {
            float diff;
            using (Image imgA = Image.FromFile(pathImgA))
            using (Image imgB = Image.FromFile(pathImgB))
            {
                diff = IsABiggerThanB(pathImgA, pathImgB) ?
                    (imgB.Width * 1.0f / imgA.Width) :
                    (imgA.Width * 1.0f / imgB.Width);
            }

            return diff;
        }

        public static int GetTotalPixel(string pathImg)
        {
            int totalPixel;
            using (Image img = Image.FromFile(pathImg))
            {
                totalPixel = img.Width * img.Height;
            }

            return totalPixel;
        }

        public static bool AreTheySimilar(string imgAPath, string imgBPath)
        {
            string bigImg = IsABiggerThanB(imgAPath, imgBPath) ? imgAPath : imgBPath;
            string smallImg = bigImg == imgAPath ? imgBPath : imgAPath;

            string resizedImagePath = ResizeWithMagick(bigImg, smallImg);
            double result = CompareWithMagick(resizedImagePath, smallImg);
            bool areTheySimilar = result / GetTotalPixel(resizedImagePath) <= marginOfErrorInPercentage;

            // Delete the resizedImage
            File.Delete(resizedImagePath);

            return areTheySimilar;
        }
    }
}

