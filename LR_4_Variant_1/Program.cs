using System;

namespace LR_4_Variant_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection collection1 = new StudentCollection();
            collection1.CollectionName = "Collection1";
            StudentCollection collection2 = new StudentCollection();
            collection2.CollectionName = "Collection2";

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            collection1.StudentCountChanged += journal1.StudentCollection_StudentCountChanged;
            collection1.StudentReferenceChanged += journal1.StudentCollection_StudentReferenceChanged;

            collection1.StudentCountChanged += journal2.StudentCollection_StudentCountChanged;
            collection1.StudentReferenceChanged += journal2.StudentCollection_StudentReferenceChanged;

            collection2.StudentCountChanged += journal2.StudentCollection_StudentCountChanged;
            collection2.StudentReferenceChanged += journal2.StudentCollection_StudentReferenceChanged;

            collection1.AddDefaults(2);
            collection1.AddStudents(new Student(new Person("Ivan","Zaharuck",new DateTime(2000,10,10)),Education.Bachelor,321 ));
            collection2.AddStudents(new Student(new Person("John", "Dfg", new DateTime(2000, 10, 10)), Education.Bachelor, 321));
            collection2.AddDefaults(1);
            collection1.Remove(2);
            collection2.Remove(0);

            collection1[0] = new Student(new Person("Edited", "Edited", new DateTime(2000, 10, 10)), Education.Bachelor,
                321);
            Console.WriteLine("Journal 1: ");
            Console.WriteLine(journal1);
            Console.WriteLine("Journal 2: ");
            Console.WriteLine(journal2);
            Console.ReadKey();
        }
    }
}
