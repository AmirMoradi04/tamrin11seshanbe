using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamrin11.Loger
{
    public class ConsoleFileLogger : ILogger
    {
        private readonly string _filePath = "log.txt";
        void ILogger.Log(string message)
        {
            Write(message, "log");
        }

        void ILogger.LogError(string message)
        {
            Write(message, "logerror");
        }

        void ILogger.LogWarning(string message)
        {
            Write(message, "logWarning");
        }
        private void Write(string message,string type)
        {
            string log = $"{type}   {message}";
            Console.WriteLine(log);
            File.AppendAllText(_filePath, log +"\n");
        }
    }
}
