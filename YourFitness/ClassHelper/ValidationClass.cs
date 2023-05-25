using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourFitness.ClassHelper
{
    class ValidationClass
    {
        public static bool validationPassword(string a)
        {
            if (string.IsNullOrWhiteSpace(a) == true)
            {
                return false;
            }

            if (a.Length < 7 || a.Length > 15)
            {
                return false;
            }


            if (a.Contains(" "))
            {
                return false;
            }

            if (!a.Any(Char.IsUpper))
            {
                return false;
            }

            if (!a.Any(Char.IsLower))
            {
                return false;
            }

            if (!a.Any(Char.IsDigit))
            {
                return false;
            }



            return true;

        }

        public static bool validationLogin(string a)
        {
            if (string.IsNullOrWhiteSpace(a) == true)
            {
                return false;
            }
           
            if (a.Length < 2 | a.Length > 50)
            {
                return false;
            }

            if (a.Contains(" "))
            {
                return false;
            }

            return true;

        }

        public static bool validationFIO(string a)
        {
            if (string.IsNullOrWhiteSpace(a) == true)
            {
                return false;
            }

            if (!a.All(Char.IsLetter))
            {
                return false;
            }

            if (a.Contains(" "))
            {
                return false;
            }

            return true;

        }

        public static bool validationWeighAndHeight(double a)
        {

            if (Convert.ToInt32(a) < 10 | Convert.ToInt32(a) > 300)
            {
                return false;
            }




            return true;
        }


       


    }
}
