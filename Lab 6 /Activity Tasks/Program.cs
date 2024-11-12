using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsolidatedActivities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Activity 1: Generic List Operations");
            GenericListActivity();

            Console.WriteLine("\nActivity 2: Dictionary Operations");
            DictionaryActivity();

            Console.WriteLine("\nActivity 3: ArrayList Operations");
            NonGenericActivity();

            Console.WriteLine("\nActivity 4: Student Management System");
            StudentsManagementSystem();

            Console.ReadLine();
        }

        // Activity 1: Generic List
        static void GenericListActivity()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4 };

            Console.WriteLine("Original List:");
            DisplayList(numbers);

            numbers.Remove(3);
            Console.WriteLine("\nList after removal:");
            DisplayList(numbers);

            numbers.Sort();
            Console.WriteLine("\nList after sorting:");
            DisplayList(numbers);
        }

        static void DisplayList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }

        // Activity 2: Dictionary Operations
        static void DictionaryActivity()
        {
            Dictionary<string, string> countries = new Dictionary<string, string>
            {
                { "USA", "Washington, D.C." },
                { "France", "Paris" },
                { "Japan", "Tokyo" },
                { "India", "New Delhi" }
            };

            Console.WriteLine("Countries and Capitals:");
            DisplayDictionary(countries);

            Console.WriteLine($"\nCapital of Japan: {countries["Japan"]}");

            countries.Remove("France");
            Console.WriteLine("\nUpdated Countries and Capitals:");
            DisplayDictionary(countries);
        }

        static void DisplayDictionary(Dictionary<string, string> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        // Activity 3: ArrayList
        static void NonGenericActivity()
        {
            ArrayList arrayList = new ArrayList { 10, "Hello", 20.5, "World" };

            Console.WriteLine("ArrayList contains:");
            DisplayArrayList(arrayList);

            arrayList.Remove("Hello");
            Console.WriteLine("\nUpdated ArrayList contains:");
            DisplayArrayList(arrayList);
        }

        static void DisplayArrayList(ArrayList list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        // Activity 4: Student Management System
        static void StudentsManagementSystem()
        {
            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>
            {
                { "Alice", new List<int> { 85, 90, 88 } },
                { "Bob", new List<int> { 78, 82, 91 } },
                { "Charlie", new List<int> { 92, 87, 94 } },
                { "David", new List<int> { 55, 60, 58 } }
            };

            DisplayStudentAverages(students);

            var topStudent = students.OrderByDescending(s => s.Value.Average()).First();
            var lowStudent = students.OrderBy(s => s.Value.Average()).First();

            Console.WriteLine($"\nTop performing student: {topStudent.Key} with average {topStudent.Value.Average():F2}");
            Console.WriteLine($"Low performing student: {lowStudent.Key} with average {lowStudent.Value.Average():F2}");

            // Remove students with average < 60
            var failingStudents = students.Where(s => s.Value.Average() < 60).Select(s => s.Key).ToList();
            foreach (var student in failingStudents)
            {
                students.Remove(student);
            }

            Console.WriteLine("\nAfter removing failing students:");
            DisplayStudentNames(students);
        }

        static void DisplayStudentAverages(Dictionary<string, List<int>> students)
        {
            Console.WriteLine("Student Averages:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}: Average = {student.Value.Average():F2}");
            }
        }

        static void DisplayStudentNames(Dictionary<string, List<int>> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.Key);
            }
        }
    }
}
