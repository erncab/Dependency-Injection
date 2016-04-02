using System;
using DI.NInject.Interfaces;

namespace DI.NInject.Classes
{
    public class Logger : ILogger
    {
        void ILogger.Log(string message)
        {
            // log message to log file
            Console.WriteLine("Log entry @ {0}: {1}", DateTime.Now, message);
            Console.WriteLine();
        }
    }
}