using System;
using DI.Unity.Interfaces;

namespace DI.Unity.Classes
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