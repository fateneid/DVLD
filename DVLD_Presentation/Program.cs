using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true) 
            {

                frmLogin login = new frmLogin();

                if (login.ShowDialog() != DialogResult.OK)
                    break;

                frmMain main = new frmMain();
                Application.Run(main);

                if (!main.IsLoggedOut)
                    break;
            }

        }

    }
}
