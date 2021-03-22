using System;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace ResizingPNG
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "";
            string[] files = Directory.GetFiles(filePath);
            string filePathToSave = "";
            int keepRatio = 81;

           foreach (var file in files)
            {
                float heigth = (float)keepRatio;
                float width = (float)keepRatio;
                var fileElements = file.Split("\\");
                var fileName = fileElements[fileElements.Length - 1];

                Image src = Image.FromFile(file);

                if (src.Height > src.Width)
                {
                    width = ((float)81 / src.Height) * src.Width;
                } 
                else
                {
                    heigth = ((float)81 / src.Width) * src.Height;
                }

                Console.WriteLine((int)Math.Round(width) + "," + (int)Math.Round(heigth));

                Bitmap dst = new Bitmap((int)Math.Round(width), (int)Math.Round(heigth));
                Graphics g = Graphics.FromImage(dst);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, dst.Width, dst.Height);
                dst.Save(filePathToSave + fileName, ImageFormat.Png);
            }
        }
    }
}
