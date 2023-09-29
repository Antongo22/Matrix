﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] n = new double[,] {
                {7, 1, 2,},
                {-2, 4, 0 },
                {4, 5, 5 } };

            double[,] m = new double[,] {
                {2, 8, 7 },
                {1, 5, 4  },
                {-6, 2, 6 } };

            
            Matrix matrix = new Matrix(n);
            Matrix matrix2 = new Matrix(m);

            Matrix newM = matrix * matrix2;

            //newM.ShowMatrix();
        }
    }
}
