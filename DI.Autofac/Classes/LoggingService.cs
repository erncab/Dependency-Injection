using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class LoggingService : ILoggingService
    {
        void ILoggingService.Log(string message)
        {
            // log message to log file
            Console.WriteLine("Log entry @ {0}: {1}", DateTime.Now, message);
            Console.WriteLine();
        }
    }
}