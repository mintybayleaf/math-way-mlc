using System;
using System.Security.Cryptography;
using System.Text;

namespace MathLib
{
    public class Lib
    {

        public static string GetSemester()
        {
            string semester = "";
            DateTime spring_b = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            DateTime spring_e = new DateTime(DateTime.Now.Year, 5, 18, 0, 0, 0);

            DateTime fall_b = new DateTime(DateTime.Now.Year, 8, 23, 0, 0, 0);
            DateTime fall_e = new DateTime(DateTime.Now.Year, 12, 31, 0, 0, 0);

            DateTime current = DateTime.Now; 

            if ((DateTime.Compare(spring_b, current) < 0) && (DateTime.Compare(current, spring_e) < 0))
            {
                semester = "SPRING" + DateTime.Now.Year.ToString();
            }
            else if ((DateTime.Compare(fall_b, current) < 0) && (DateTime.Compare(current, fall_e) < 0))
            {
                semester = "FALL" + DateTime.Now.Year.ToString();
            }
            else
            {
                semester = "SUMMER" + DateTime.Now.Year.ToString();
            }


            return semester;

        }

        public static UInt64 FixTime(DateTime time)
        {
            UInt64 minutes = (UInt64)time.Minute;
            UInt64 hours = (UInt64)(time.Hour * 60);

            return minutes + hours;

        }

        public static string Get256Hash(string raw)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(raw));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
