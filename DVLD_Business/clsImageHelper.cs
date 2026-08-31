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

        private static readonly string _ImagesDirectory = @"C:\DVLD_Images";

        public static string SaveImage(string newImagePath)
        {
            if (string.IsNullOrEmpty(newImagePath)) return "";

            try
            {
                if (!Directory.Exists(_ImagesDirectory))
                    Directory.CreateDirectory(_ImagesDirectory);

                string extension = Path.GetExtension(newImagePath);
                string newFileName = Guid.NewGuid() + extension;
                string destinationPath = Path.Combine(_ImagesDirectory, newFileName);

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
