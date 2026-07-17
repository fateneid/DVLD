using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsImageHelper
    {

        public static string SaveImage(string newImagePath, string imagesDirectory)
        {
            if (string.IsNullOrEmpty(newImagePath)) return "";

            try
            {
                if (!Directory.Exists(imagesDirectory))
                    Directory.CreateDirectory(imagesDirectory);

                string extension = Path.GetExtension(newImagePath);
                string newFileName = Guid.NewGuid() + extension;
                string destinationPath = Path.Combine(imagesDirectory, newFileName);

                File.Copy(newImagePath, destinationPath);

                return destinationPath;

            }
            catch
            {
                return "";
            }
            
        }

        public static void DeleteImage(string ImagePath)
        {
            if (string.IsNullOrWhiteSpace(ImagePath))
                return;

            if (File.Exists(ImagePath))
                File.Delete(ImagePath);
        }

    }
}
