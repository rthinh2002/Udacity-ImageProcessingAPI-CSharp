using System.Drawing;
using System.IO;

namespace Image_Processor.Models
{
    public class Image
    {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Image(string _FileName, int _Width, int _Height) 
        {
            FileName = _FileName;
            Width = _Width;
            Height = _Height;
        }

        public Image(string _FileName) 
        {
            FileName = _FileName;
        }

        
        public bool VerifyPath(string Folder)
        {
            string path = "";
            if(Folder == "images")
            {
                path = Path.Combine("Data", Folder, $"{FileName}.jpg");
            } else
            {
                path = Path.Combine("Data", Folder, $"{FileName}-{Width}x{Height}.jpg");
            }
            return File.Exists(path);
        }

        public string CreatePathToThumbnails()
        {
            return Path.Combine("Data", "thumbnails", $"{FileName}-{Width}x{Height}.jpg");
        }

        public string GetPathToImage()
        {
            return Path.Combine("Data", "images", $"{FileName}.jpg");
        }

        public void ResizeImage()
        {
            string path = GetPathToImage();
            string thumbnailPath = CreatePathToThumbnails();

            using (var image = System.Drawing.Image.FromFile(path))
            {
                var resizedImage = new Bitmap(Width, Height);

                using(var graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    graphics.DrawImage(image, 0, 0, Width, Height);
                }
                resizedImage.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        
    }
}
