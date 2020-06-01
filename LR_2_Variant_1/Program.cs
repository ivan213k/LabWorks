using System;
using System.Collections;
namespace LR_2_Variant_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Ivan","Zaharuck",new DateTime(2000,08,13));
            Person person2 = person1.DeepCopy() as Person;
            Console.WriteLine($"person1 ref equal person2 ={ReferenceEquals(person1, person2)}");
            Console.WriteLine($"person1 hash code - {person1.GetHashCode()}");
            Console.WriteLine($"person2 hash code - {person2.GetHashCode()}");

            Student student = new Student(person1,Education.Bachelor,321);
            student.AddExams(new Exam("Math",4, new DateTime(2018,12,15)));
            student.AddExams(new Exam(".Net", 5, new DateTime(2018, 12, 11)));
            student.AddExams(new Exam("History", 2, new DateTime(2018, 12, 16)));
            student.AddCredit(new Test("Biology", true));
            student.AddCredit(new Test("Python", true));
            student.AddCredit(new Test("Java", false));

            Console.WriteLine(student);
            Console.WriteLine("\n" + student.Person);

            Student studentCopy = student.DeepCopy() as Student;

            student.GroupId = 401;
            student.EducationForm = Education.Master;
            student.Person.Name = "John";
            student.Person.SurName = "Tesr";
            student.Credits = new ArrayList();
            student.Exams = new ArrayList();

            Console.WriteLine("Original: ");
            Console.WriteLine(student);
            Console.WriteLine("Deep Copy: ");
            Console.WriteLine(studentCopy);

            try
            {
                student.GroupId = 999;
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Помилка, введене значення неприпустиме!");
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            foreach (Exam exam in studentCopy.GetExams(3))
            {
                Console.WriteLine(exam);
            }
            Console.ReadKey();
        }
    }
}
