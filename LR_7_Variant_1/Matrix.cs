using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LR_7_Variant_1
{
    class Matrix
    {
        public int Row { get; set; }
        public int Column { get; set; }
        double[,] arr;
        public static Mutex mutex = new Mutex();

        Matrix() { }
        public Matrix(int row, int column)
        {
            Row = row;
            Column = column;
            arr = new double[row, column];
        }
        public double[] GetColumn(int i)
        {
            double[] res = new double[Row];
            for (int j = 0; j < Row; j++)
                res[j] = arr[j, i];
            return res;
        }
        public double[] GetRow(int i)
        {
            double[] res = new double[Column];
            for (int j = 0; j < Column; j++)
                res[j] = arr[i, j];
            return res;
        }
        public double this[int i, int j]
        {
            get { return arr[i, j]; }
            set { arr[i, j] = value; }
        }
        public Matrix RandomValues(int min = 0, int max = 100)
        {
            Random rnd = new Random();
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                    arr[i, j] = rnd.Next(min,max);
            return this;
        }

        public void Print()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.Row, b.Column);
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < a.Row; i++)
                for (int j = 0; j < b.Column; j++)
                {
                    int tempi = i;
                    int tempj = j;
                    Thread thread = new Thread(() => VectorMult(tempi, tempj, a, b, result));
                    thread.Start();
                    threads.Add(thread);
                }
            foreach (Thread t in threads)
                t.Join();
            return result;
        }

        public static void VectorMult(int tmpi, int tmpj, Matrix a, Matrix b, Matrix result)
        {
            mutex.WaitOne();
            int i = tmpi;
            int j = tmpj;
            double[] x = a.GetRow(i);
            double[] y = b.GetColumn(j);

            for (int k = 0; k < x.Length; k++)
                result[i, j] += x[k] * y[k];

            mutex.ReleaseMutex();
        }
    }
}
