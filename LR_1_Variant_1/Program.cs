using System;
using System.Diagnostics;

namespace LR_1_Variant_1
{
    class Program
    {
        static Exam[] InitArray(int count)
        {
            Exam[] exams = new Exam[count];
            for (int i = 0; i < count; i++)
            {
                exams[i] = new Exam();
            }

            return exams;
        }

        static Exam[,] InitMatrix(int rows, int cols)
        {
            Exam[,] exams = new Exam[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    exams[i,j] = new Exam();
                }
            }
            return exams;
        }

        static Exam[][] InitJugedArray(int rows, int cols)
        {
            Exam[][] exams = new Exam[rows][];
            for (int i = 0; i < rows; i++)
            {
                exams[i] = new Exam[cols];
                for (int j = 0; j < exams[i].Length; j++)
                {
                    exams[i][j] = new Exam();
                }
            }
            return exams;
        }
        static void TestArraysPerformance(int rows, int cols)
        {
            Exam[] examsArray = InitArray(rows*cols);
            Exam[,] matrix = InitMatrix(rows,cols);
            Exam[][] jugedExams = InitJugedArray(rows,cols);

            Stopwatch arrayTime = new Stopwatch();
            arrayTime.Start();
            for (int i = 0; i < examsArray.Length; i++)
            {
                examsArray[i].Mark = 5;
            }
            arrayTime.Stop();

            Stopwatch matrixTime = new Stopwatch();
            matrixTime.Start();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j].Mark = 5;
                }
            }
            matrixTime.Stop();

            Stopwatch jugedArrayTime = new Stopwatch();
            jugedArrayTime.Start();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    jugedExams[i][j].Mark = 5;
                }
            }
            jugedArrayTime.Stop();

            Console.WriteLine($"Одновимiрний масив - {arrayTime.ElapsedTicks} ticks");
            Console.WriteLine($"Двовимiрний масив  - {matrixTime.ElapsedTicks} ticks");
            Console.WriteLine($"Зубчастий масив - {jugedArrayTime.ElapsedTicks} ticks");
        }
        static void Main(string[] args)
        {
            Student student = new Student(new Person("Iван", "Захарук", new DateTime(2000, 08, 13)), Education.Bachelor, 321);
            student.AddExams(new Exam("Math", 5, new DateTime(2018, 12, 15)), 
                new Exam("Biology", 4, new DateTime(2018, 12, 15)));
            Console.WriteLine(student.ToShortString());
            Console.WriteLine();

            Console.WriteLine(student[Education.Bachelor]);
            Console.WriteLine(student[Education.Master]);
            Console.WriteLine(student[Education.SecondEducation]);

            Console.WriteLine();
            Console.WriteLine(student.ToString());

            Console.WriteLine();
            Console.Write("Введiть кiлькiсть рядкiв та стовпцiв через пробiл: ");
            string input = Console.ReadLine();
            int rows = int.Parse(input.Split(" ")[0]);
            int cols = int.Parse(input.Split(" ")[1]);
            TestArraysPerformance(rows, cols);
            Console.ReadKey();
        }
    }
}
