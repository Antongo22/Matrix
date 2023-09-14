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
            int[,] m = new int[,] {{ 5, 4}, { 1, 5 } };
        
            Matrix matrix = new Matrix(m);
        }
    }
}
