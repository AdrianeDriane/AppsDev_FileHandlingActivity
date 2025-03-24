using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace StoreAndDisplayStudent { 
    class StoreAndDisplayStudent
    {
        static void Main()
        {
            string fileName = "../../../../../files/students.txt";

            while (true)
            {
                Console.Write("Enter student name (or type 'exit' to stop): ");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                    break;

                Console.Write("Enter student score: ");
                if (int.TryParse(Console.ReadLine(), out int score))
                {
                    string record = $"{name},{score}";
                    File.AppendAllText(fileName, record + Environment.NewLine);
                    Console.WriteLine("Record added.");
                }
                else
                {
                    Console.WriteLine("Invalid score. Please enter a number.");
                }
            }

            if (File.Exists(fileName))
            {
                var records = File.ReadAllLines(fileName)
                                   .Select(line => line.Split(','))
                                   .Where(parts => parts.Length == 2)
                                   .Select(parts => new { Name = parts[0], Score = int.Parse(parts[1]) })
                                   .ToList();

                if (records.Any())
                {
                    int highestScore = records.Max(r => r.Score);
                    var topStudents = records.Where(r => r.Score == highestScore);

                    Console.WriteLine("\nStudent/s with the highest score:");
                    foreach (var student in topStudents)
                    {
                        Console.WriteLine($"{student.Name} - {student.Score}");
                    }
                }
                else
                {
                    Console.WriteLine("No student records found.");
                }
            }
            else
            {
                Console.WriteLine("No student records found.");
            }
        }
    }
}