using System;
using System.IO;

namespace FileReader
{
    class FileReader
    {
        static void Main()
        {
            Console.Write("Enter the file name to read: ");
            string fileName = Console.ReadLine();

            if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            string filePath = "../../../../../files/" + fileName;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    Console.WriteLine("File Content:");
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
