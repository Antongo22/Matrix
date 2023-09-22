using System;
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
            int[,] m = new int[,] {
                {1, -2, 1,}, 
                {3, 1, -1 },
                {-1, 1, 1  } };

            int[,] n = new int[,] {
                {1, -2, 1,},
                {3, 1, -1 },
                {-1, 1, 1  } };


            Matrix matrix = new Matrix(m);
            Matrix matrix2 = new Matrix(n);

            Matrix newM = matrix * 5;

            //newM.ShowMatrix();
        }
    }
}
