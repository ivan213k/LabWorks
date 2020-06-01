using System;
using System.IO;

namespace LR_5_Variant1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(new Person("Ivan","Zaharuck",new DateTime(2000,02,02)),Education.Bachelor,321);
            student.AddExams(new Exam("Test sub",5, new DateTime(2020,10,10)));

            Student studentCopy = student.DeepCopy();
            Console.WriteLine("Origianl");
            Console.WriteLine(student);
            Console.WriteLine("Copy");
            Console.WriteLine(studentCopy);

            Console.Write("Введіть iм'я файлу: ");
            string fileName = Console.ReadLine();
            if (File.Exists(fileName))
            {
                Console.WriteLine("Файл iснує, завантаження з файлу...");
                student.Load(fileName);
            }
            else
            {
                Console.WriteLine("Файл буде створено...");
                student.Save(fileName);
            }
            Console.WriteLine(student);

            student.AddExamFromConsole();
            student.Save(fileName);
            Console.WriteLine(student);

            Student.Load(fileName, student);
            student.AddExamFromConsole();
            Student.Save(fileName, student);
            Console.WriteLine(student);
            Console.ReadKey();
        }
    }
}
