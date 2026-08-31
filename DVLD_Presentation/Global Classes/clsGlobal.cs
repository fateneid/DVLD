using DVLD_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Global_Classes
{
    internal static class clsGlobal
    {

        public static clsUser CurrentUser;

        private static readonly string _RememberMeFile =
               Path.Combine(Application.StartupPath, "RememberMe.txt");

        public static bool SaveRememberedCredentials(string Username, string Password) 
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_RememberMeFile))
                {
                    writer.WriteLine(Username);
                    writer.WriteLine(Password);
                }

                return true;
            }
            catch 
            {
                return false;
            }              
        }

        public static bool ClearRememberedCredentials() 
        {
            try 
            {
                if (File.Exists(_RememberMeFile))
                    File.Delete(_RememberMeFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadRememberedCredentials(ref string Username, ref string Password)
        {
            try
            {
                if (!File.Exists(_RememberMeFile))
                    return false;
                
                string[] data = File.ReadAllLines(_RememberMeFile);

                if (data.Length < 2)
                    return false;

                Username = data[0];
                Password = data[1];

                return true;
                
            }
            catch
            {
                return false;
            }

        }

    }
}
