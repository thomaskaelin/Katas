using System;

namespace KataSmells.Example3
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
