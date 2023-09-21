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
        
            Matrix matrix = new Matrix(m);
            int[] k = { 1, 7, -3 };
            matrix.SetKramer(k);
            matrix.Kramer();
        }
    }
}
