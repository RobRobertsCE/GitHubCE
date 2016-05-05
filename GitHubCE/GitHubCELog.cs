using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCE
{
    public static class GitHubCELog
    {
        private static string _logFilePath = @"C:\logs\GitHubCE\GitHubCELog.txt";

        public static void Log(string message)
        {
            using (StreamWriter w = File.AppendText(_logFilePath))
            {
                Log(message, w);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public static string GetLogContent()
        {
            return File.ReadAllText(_logFilePath);
        }
    }
}
