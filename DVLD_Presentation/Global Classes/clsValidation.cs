using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Presentation.Global_Classes
{
    public class clsValidation
    {

        public static bool ValidateEmail(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }

        }


    }
}
