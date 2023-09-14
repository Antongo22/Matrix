using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matrix
    {
        int[,] matrix;

        public Matrix(int[,] matrix) 
        { 
            this.matrix=matrix;

            ShowMatrix(matrix);

            Console.WriteLine(SolutionMatrix(matrix));
        }
        
        void ShowMatrix(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("  " + matrix[i, j] + ", ");
                }
                Console.WriteLine("|");
            }
        }


        int Solution(int[,] tMatrix)
        {
            return tMatrix[0, 0] * tMatrix[1, 1] - tMatrix[0, 1] * tMatrix[1, 0];
        }

        int  SolutionMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) == 2)
            {
                return Solution(matrix);
            }

            int[] matrixMinor = new int[matrix.GetLength(0)];
            int[,] matrixM = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            int[,,] smallMatrix = new int[matrix.GetLength(0), matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            int solution = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixMinor[i] = matrix[0, i];              
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (k != i && j != 0)
                        {
                            //Console.WriteLine(matrix[j, k]);
                            smallMatrix[i, j - 1, (k < i ? k : k - 1) ] = matrix[j, k];
                            //Console.WriteLine(smallMatrix[i, j - 1, (k < i ? k : k - 1)]);
                        }

                    }

                }
                Console.WriteLine();
            }

            for (int i = 0; i < smallMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < smallMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < smallMatrix.GetLength(1); k++)
                    {
                        matrixM[j, k] = smallMatrix[i, j, k];                        
                    }
                }
                ShowMatrix(matrixM);
                Console.WriteLine();
                int a = matrixMinor[i] * SolutionMatrix(matrixM);
                //Console.WriteLine(a);
                solution += i % 2 == 0 ? a : (-1*a);
            }

            return solution ;
        }
    }
}
