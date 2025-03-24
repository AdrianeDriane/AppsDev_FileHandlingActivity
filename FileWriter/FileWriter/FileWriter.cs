using System;
using System.IO;

namespace FileWriter
{
    class FileWriter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Writer Program");
            Console.WriteLine("------------------");

            Console.Write("Enter the file name: ");
            string fileName = Console.ReadLine();

            if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            try
            {
                using (StreamWriter writer = new StreamWriter("../../../../../files/" + fileName))
                {
                    Console.WriteLine($"\nEnter text to write to {fileName}");
                    Console.WriteLine("Type 'EXIT' on a new line to finish");
                    Console.WriteLine("------------------");

                    string line;
                    do
                    {
                        line = Console.ReadLine();

                        if (!(line.ToLower() == "exit"))
                        {
                            writer.WriteLine(line);
                        }

                    } while (!(line.ToLower() == "exit"));

                    Console.WriteLine($"\nFile saved successfully as {fileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}