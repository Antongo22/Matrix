using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matrix
    {
        int matrixLength;
        int[,] matrix;

        public Matrix(int[,] matrix) 
        { 
            this.matrix=matrix;

            matrixLength = matrix.Length;

            Console.WriteLine(Solution(matrix));
        }
        
        int Solution(int[,] tMatrix)
        {
            return tMatrix[0, 0] * tMatrix[1, 1] - tMatrix[0, 1] * tMatrix[1, 0];
        }
    }
}
