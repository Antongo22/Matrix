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
            int[,] m = new int[,] {{ 1, 0, 3}, { -7, 5, 4 }, {3, 1, 5 } };
        
            Matrix matrix = new Matrix(m);
        }
    }
}
