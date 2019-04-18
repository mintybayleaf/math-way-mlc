using System;
using System.IO;

namespace MathLib
{
    public class Logger
    {
        private readonly string fileName = "MLCLog.log";
        private readonly uint maxSize = 1024 * 1024; // 1024 Kilobytes is the max number of bytes per file
        public static Logger log = new Logger();

      

        // Return the logger instance
        public static Logger Instance 
        {
            get { return log; }
        }


        // Public Wrapper to write the log
        public void WriteLog(string d = "DEBUG", string msg = "")
        {
             this.Write(d, msg);
        }


        // Add some methods too use for the logger class
        private async void Write(string danger = "DEBUG", string message = "")
        {

            try {
                
                String msg = "";
                Stream file = new FileStream(fileName, FileMode.Append, FileAccess.Write);
               
                // If the size is bigger than the max 
                // Rename and move the file to LogFolder
                // Remake the file!
                if (file.Length > maxSize)
                {
                    file.Close();
                    Directory.CreateDirectory("LogFolder");
                    string newName = fileName.Substring(0, fileName.IndexOf('.')) + "_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".log";
                    FileInfo fi = new FileInfo(fileName);
                    fi.MoveTo("LogFolder" + "\\" + newName);
                    file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                }

                switch (danger.ToUpper())
                {
                    case "DEBUG":
                        msg += "[DEBUG]";
                        break;
                    case "WARNING":
                        msg += "[WARNING]";
                        break;
                    case "FATAL":
                        msg += "[FATAL]";
                        break;
                    default:
                        break;
                }

                msg += " [" + DateTime.Now.ToShortTimeString() + "] " + "[" + DateTime.Now.ToShortDateString() + "] " + message + Environment.NewLine;
                StreamWriter stream = new StreamWriter(file);

                await stream.WriteAsync(msg);
                stream.Close();

            }
            catch(Exception ex)
            {
                // Silently Continue 
            }
       }

    }
}
