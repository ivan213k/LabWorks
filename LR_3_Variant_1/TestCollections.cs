using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LR_3_Variant_1
{
    class TestCollections
    {
        public List<Student> StudentsList { get; set; }

        public List<string> StudentsStrings { get; set; }

        public Dictionary<Person, Student> PersonStudentsDictionary { get; set; }

        public Dictionary<string, Student> StringStudentDictionary { get; set; }

        public TestCollections(int n)
        {
            StudentsList = new List<Student>();
            StudentsStrings = new List<string>();
            PersonStudentsDictionary = new Dictionary<Person, Student>();
            StringStudentDictionary = new Dictionary<string, Student>();
            for (int i = 0; i < n; i++)
            {
                Student generatedStudent = GenerateStudent(i);
                StudentsList.Add(generatedStudent);
                StudentsStrings.Add(generatedStudent.ToString());
                PersonStudentsDictionary.Add(generatedStudent.Person, generatedStudent);
                StringStudentDictionary.Add(generatedStudent.Person.ToString(), generatedStudent);
            }
        }

        public static Student GenerateStudent(int n)
        {
            return new Student(new Person($"Test {n}","Surname",new DateTime(2000,08,08)),Education.Bachelor,321);
        }

        public void TestStudentsList(Student element)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (StudentsList.Contains(element))
            {
                stopwatch.Stop();
                Console.WriteLine($"Елемент знайдено. Час: {stopwatch.ElapsedTicks} ticks");
            }
            else
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Елемент не знайдено. Час: {stopwatch.ElapsedTicks} ticks");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public void TestStudentsStrings(string element)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (StudentsStrings.Contains(element))
            {
                stopwatch.Stop();
                Console.WriteLine($"Елемент знайдено. Час: {stopwatch.ElapsedTicks} ticks");
            }
            else
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Елемент не знайдено. Час: {stopwatch.ElapsedTicks} ticks");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public void TestDictionaryKeySearch(Person person)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (PersonStudentsDictionary.ContainsKey(person))
            {
                stopwatch.Stop();
                Console.WriteLine($"Елемент знайдено. Час: {stopwatch.ElapsedTicks} ticks");
            }
            else
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Елемент не знайдено. Час: {stopwatch.ElapsedTicks} ticks");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public void TestDictionaryValueSearch(Student student)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (StringStudentDictionary.ContainsValue(student))
            {
                stopwatch.Stop();
                Console.WriteLine($"Елемент знайдено. Час: {stopwatch.ElapsedTicks} ticks");
            }
            else
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Елемент не знайдено. Час: {stopwatch.ElapsedTicks} ticks");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
