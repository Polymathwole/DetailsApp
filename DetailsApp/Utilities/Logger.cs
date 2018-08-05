using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DetailsApp.Utilities
{

    public class Logger
    {
        private string path = string.Empty;

        public Logger(string pat)
        {
            path = pat;
        }

        public void WriteEvent(string[] msg)
        {
            string eventFilePath = path + @"Details App\Event logs\";
            string textPath = string.Empty;
            DateTime now = DateTime.Now;

            if (!Directory.Exists(eventFilePath))
            {
                Directory.CreateDirectory(eventFilePath);
            }

            textPath = eventFilePath + $"Details App event log {now.ToString("ddMMyyyy")}.txt";

            using (StreamWriter sw = new StreamWriter(textPath, true))
            {
                sw.WriteLine($"Timestamp: {now.ToString("ddMMyyy hh:mm:ss")}");

                string message = string.Empty;
                foreach (string m in msg)
                {
                    message += $"{{{m}}}";
                }
                sw.WriteLine(message);
                sw.WriteLine("---------------------------------------------");
                sw.WriteLine();
            }
                
        }

        public void WriteError(string[] msg)
        {
            string errorFilePath = path + @"Details App\Error logs\";
            string textPath = string.Empty;
            DateTime now = DateTime.Now;

            if (!Directory.Exists(errorFilePath))
            {
                Directory.CreateDirectory(errorFilePath);
            }

            textPath = errorFilePath + $"Details App error log {now.ToString("ddMMyyyy")}.txt";

            using (StreamWriter sw = new StreamWriter(textPath, true))
            {
                sw.WriteLine($"Timestamp: {now.ToString("ddMMyyy hh:mm:ss")}");
                string message = string.Empty;
                foreach (string m in msg)
                {
                    message += $"{{{m}}}";
                }
                sw.WriteLine(message);
                sw.WriteLine("---------------------------------------------");
                sw.WriteLine();
            }
        }
    }
}
