using System;

namespace LR_3_Variant_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentColection students = new StudentColection();
            Student student1 = new Student(new Person("Ivan", "Zaharuck", new DateTime(2000, 10, 10)),
                Education.Master, 321);
            student1.AddExams(new Exam("test",4,DateTime.Now));
            student1.AddExams(new Exam("Test 1",5, DateTime.Now));

            Student student2 = new Student(new Person("John", "Petrov", new DateTime(2001, 10, 10)),
                Education.Bachelor, 381);
            student2.AddExams(new Exam("test", 3, DateTime.Now));
            student2.AddExams(new Exam("Test 1", 4, DateTime.Now));

            Student student3 = new Student(new Person("Roma", "Dirun", new DateTime(2002, 10, 10)),
                Education.Bachelor, 321);
            student3.AddExams(new Exam("test", 5, DateTime.Now));
            student3.AddExams(new Exam("Test 1", 5, DateTime.Now));
            
            students.AddStudents(student1,student2,student3);

            Console.WriteLine(students);
            Console.WriteLine("-------------Sorting surname____________________");
            students.SortBySurname();
            Console.WriteLine(students);
            Console.WriteLine("-------------Sorting BirthDay____________________");
            students.SortByBirthDay();
            Console.WriteLine(students);
            Console.WriteLine("-------------Sorting AvverageMark____________________");
            students.SortByAvverageMark();
            Console.WriteLine(students);
            Console.WriteLine("******************************************************");
            Console.WriteLine($"Максимальний середнiй бал: {students.GetMaxAvverageMark}");
            foreach (var ms in students.MasterStudents)
            {
                Console.WriteLine(ms);
            }

            foreach (var stud in students.GetStudentWithAvverageMark(4.5))
            {
                Console.WriteLine(stud);
            }

            Console.WriteLine("--------------Collection Performance Test");
            Console.Write("Введiть кiлькicть елемнтiв: ");
            int n = 0;
            while(!int.TryParse(Console.ReadLine(),out n))
            {
                Console.WriteLine("Помилка, cпробуйте ще раз: ");
            }

            Console.WriteLine("--------List<Student>");
            Console.WriteLine("First Element: ");
            TestCollections testCollections = new TestCollections(n);
            testCollections.TestStudentsList(TestCollections.GenerateStudent(0));
            Console.WriteLine("Middele Element");
            testCollections.TestStudentsList(TestCollections.GenerateStudent(n/2));
            Console.WriteLine("Last Element");
            testCollections.TestStudentsList(TestCollections.GenerateStudent(n-1));
            Console.WriteLine("Not Exist element");
            testCollections.TestStudentsList(TestCollections.GenerateStudent(n + 1));

            Console.WriteLine("--------List<string>");
            Console.WriteLine("First Element: ");
            testCollections.TestStudentsStrings((TestCollections.GenerateStudent(0).ToString()));
            Console.WriteLine("Middele Element");
            testCollections.TestStudentsStrings(TestCollections.GenerateStudent(n / 2).ToString());
            Console.WriteLine("Last Element");
            testCollections.TestStudentsStrings(TestCollections.GenerateStudent(n - 1).ToString());
            Console.WriteLine("Not Exist element");
            testCollections.TestStudentsStrings(TestCollections.GenerateStudent(n + 1).ToString());

            Console.WriteLine("--------Dictionary<Person,Student>");
            Console.WriteLine("First Element: ");
            testCollections.TestDictionaryKeySearch((TestCollections.GenerateStudent(0)));
            Console.WriteLine("Middele Element");
            testCollections.TestDictionaryKeySearch(TestCollections.GenerateStudent(n / 2));
            Console.WriteLine("Last Element");
            testCollections.TestDictionaryKeySearch(TestCollections.GenerateStudent(n - 1));
            Console.WriteLine("Not Exist element");
            testCollections.TestDictionaryKeySearch(TestCollections.GenerateStudent(n + 1));

            Console.WriteLine("--------Dictionary<string,Student>");
            Console.WriteLine("First Element: ");
            testCollections.TestDictionaryValueSearch((TestCollections.GenerateStudent(0)));
            Console.WriteLine("Middele Element");
            testCollections.TestDictionaryValueSearch(TestCollections.GenerateStudent(n / 2));
            Console.WriteLine("Last Element");
            testCollections.TestDictionaryValueSearch(TestCollections.GenerateStudent(n - 1));
            Console.WriteLine("Not Exist element");
            testCollections.TestDictionaryValueSearch(TestCollections.GenerateStudent(n + 1));
            Console.ReadKey();
        }
    }
}
