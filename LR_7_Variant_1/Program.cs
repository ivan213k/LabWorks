using System;

namespace LR_7_Variant_1
{
    class Program
    {
        static int InputInt(string message)
        {
            Console.WriteLine(message);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Помилка, спробуйте ще раз");
            }
            return n;
        }
        static void Main(string[] args)
        {
            int r1, r2, c1, c2 = 0;
            Console.WriteLine("Перша матриця");
            r1 = InputInt("Кiлькiсть рядкiв: ");
            c1 = InputInt("Кiлькiсть cтовпцiв: ");
            Console.WriteLine("Друга матриця");
            r2 = InputInt("Кiлькiсть рядкiв: ");
            c2 = InputInt("Кiлькiсть cтовпцiв: ");

            Matrix matrix1 = new Matrix(r1,c1);
            matrix1.RandomValues();
            Matrix matrix2 = new Matrix(r2, c2);
            matrix2.RandomValues();
            if (r1 <=10 &&r2 <=10 && c1<=10 && c2 <= 10)
            {
                Console.WriteLine("Matrix 1");
                matrix1.Print();

                Console.WriteLine("Matrix 1");
                matrix2.Print();
            }

            Console.WriteLine("Множення триває...");
            Matrix matrix3 = matrix1 * matrix2;
            Console.WriteLine("Множення завершено...");
            Console.WriteLine("Multiplication m1 * m2: ");
            if (matrix3.Column<=20&& matrix3.Row<=20)
            {
                matrix3.Print();
            }
            Console.ReadKey();
        }
    }
}
