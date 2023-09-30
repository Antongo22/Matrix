using System;

namespace Matrix
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            //double[,] n = new double[,] {
            //    {2, -1, 1,},
            //    {0, -4, 5 },
            //    {1, -2, 2 } };

            double[,] m = new double[,] {
                {7, 4, -2 },
                {5, 2, 3  },
                {8, -9, -1 } };

            
            //Matrix matrix = new Matrix(n);
            Matrix matrix2 = new Matrix(m);

            //Matrix newM = matrix.InverseMatrix();
            matrix2.Kramer(2, -3, 1);
            matrix2.ShowKramer();
            //newM.ShowMatrix();
        }
        }
    }
