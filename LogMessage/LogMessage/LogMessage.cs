using System;
using System.IO;

namespace LogMessage { 
    class LogMessage
    {
        static void Main()
        {
            string logFileName = "../../../../../files/logs/log.txt";

            while (true)
            {
                Console.Write("Enter a log message (or type 'exit' to quit): ");
                string message = Console.ReadLine();

                if (message.ToLower() == "exit")
                {
                    Console.Write("\nLogs are located in FileHandlingActivity/files/logs/log.txt");
                    break;
                }
                    

                string logEntry = $"{DateTime.Now}: {message}";

                try
                {
                    File.AppendAllText(logFileName, logEntry + Environment.NewLine);
                    Console.WriteLine("Log entry added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}