using System;
using System.Globalization;

namespace MathLib

{
    public static class Validate
    {
       
        public static bool strict_date(string validate, string exact = "MM/dd/yyyy HH:mm:ss")
        {
            if(string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValid = false;
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime res;
            isValid = DateTime.TryParseExact(validate, exact, provider, DateTimeStyles.None, out res);
            return isValid;
        }

        public static bool loose_date(string validate)
        {
            if (string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValid = false;
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime res;
            isValid = DateTime.TryParse(validate, provider, DateTimeStyles.None, out res);
            return isValid;
        }

        public static bool number(string validate)
        {
            if (string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValid = false;
            UInt64 res;
            isValid = UInt64.TryParse(validate,  out res);
            return isValid;
        }


        public static bool loose_string(string validate)
        {
            if (string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValidCharacter = false;
            isValidCharacter = true;
            foreach(char letter in validate)
            {

                if (Char.IsPunctuation(letter) && letter != '-')
                {
                    isValidCharacter = false;
                }

                if (Char.IsNumber(letter))
                {
                    isValidCharacter = false;
                }

            }
            return isValidCharacter;
        }


        public static bool strict_string(string validate)
        {
            if (string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValidCharacter = false;
            isValidCharacter = true;
            foreach (char letter in validate)
            {
                if (Char.IsPunctuation(letter) && letter != '-')
                {
                    isValidCharacter = false;
                }

                if (Char.IsNumber(letter))
                {
                    isValidCharacter = false;
                }

                if (Char.IsSymbol(letter))
                {
                    isValidCharacter = false;
                }
            }
            return isValidCharacter;
        }

        public static bool letter_string(string validate)
        {
            if (string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValidCharacter = false;
            isValidCharacter = true;
            foreach (char letter in validate)
            {
                if (!Char.IsLetter(letter))
                {
                    isValidCharacter = false;
                }
            }

            return isValidCharacter;
        }

        public static bool number_string(string validate)
        {
            if (string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValidCharacter = false;
            isValidCharacter = true;
            foreach (char letter in validate)
            {
                if (!Char.IsNumber(letter))
                {
                    isValidCharacter = false;
                }
            }

            return isValidCharacter;
        }

        public static bool password_string(string validate)
        {
            if (string.IsNullOrEmpty(validate))
            {
                return false;
            }
            bool isValidCharacter = false;
            if(validate.Length > 7 && validate.Length < 25)
            {
                isValidCharacter = true;
            }

            return isValidCharacter;
        }


    }



}
