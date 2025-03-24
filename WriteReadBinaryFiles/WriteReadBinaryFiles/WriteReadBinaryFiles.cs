using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

// i used json instead of binary file because BinaryFormatter is deprecated and no longer supported
class Student
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
    public string Address { get; set; }
}

class Program
{
    static void Main()
    {
        string fileName = "../../../../../files/json_files/students.json";
        List<Student> students = new List<Student>();

        if (File.Exists(fileName))
        {
            string existingJson = File.ReadAllText(fileName);
            if (!string.IsNullOrWhiteSpace(existingJson))
            {
                students = JsonSerializer.Deserialize<List<Student>>(existingJson) ?? new List<Student>();
            }
        }

        while (true)
        {
            Console.Write("Enter student name (or type 'exit' to stop): ");
            string name = Console.ReadLine();

            if (name.ToLower() == "exit")
                break;

            Console.Write("Enter student score: ");
            if (!int.TryParse(Console.ReadLine(), out int score))
            {
                Console.WriteLine("Invalid score. Please enter a number.");
                continue;
            }

            Console.Write("Enter student age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age. Please enter a number.");
                continue;
            }

            Console.Write("Enter student grade: ");
            string grade = Console.ReadLine();

            Console.Write("Enter student address: ");
            string address = Console.ReadLine();

            students.Add(new Student { Name = name, Score = score, Age = age, Grade = grade, Address = address });
        }

        string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, jsonString);
        Console.WriteLine("Student records saved successfully.");

        if (File.Exists(fileName))
        {
            jsonString = File.ReadAllText(fileName);
            students = JsonSerializer.Deserialize<List<Student>>(jsonString);

            Console.WriteLine("\nStudents loaded from file:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Score: {student.Score}, Age: {student.Age}, Grade: {student.Grade}, Address: {student.Address}");
            }
        }
        else
        {
            Console.WriteLine("No student records found.");
        }
    }
}