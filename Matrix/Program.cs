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
            double[,] m = new double[,] {
                {2, -1, 1,}, 
                {0, -4, 5 },
                {1, -2, 2  } };



            Matrix matrix = new Matrix(m);

            matrix.CulcDeterminant();

            //newM.ShowMatrix();
        }
    }
}
