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

        public static bool ValidateEmail(string Email)
        {
            try
            {
                return new MailAddress(Email).Address == Email;
            }
            catch
            {
                return false;
            }

        }

        public static bool IsDecimal(string Value)
        {
            return decimal.TryParse(Value, out _);
        }


    }
}
