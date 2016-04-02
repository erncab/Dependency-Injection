using System;

namespace DI.Coupled.Services
{
    public class LoggerService
    {
        public void Log(string message)
        {
            // log message to log file
            Console.WriteLine("Log entry @ {0}: {1}", DateTime.Now, message);
            Console.WriteLine();
        }
    }
}
