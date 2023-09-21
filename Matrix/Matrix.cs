using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matrix
    {
        int[,] matrix;
        string filename = "data.txt";

        public Matrix(int[,] matrix)
        {
            File.Create(filename).Close();
            this.matrix = matrix;

            ShowMatrix(matrix);
        }

        public void CulcDeterminant()
        {
            int solution = SolutionMatrix(matrix);
            Console.WriteLine(solution);
            File.AppendAllText(filename, "\n" + solution);
        }

        void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                File.AppendAllText(filename, "|");
                Console.Write("|");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    File.AppendAllText(filename, "" + matrix[i, j] + ",\t");
                    Console.Write("" + matrix[i, j] + ",\t");
                }
                File.AppendAllText(filename, "|\n");
                Console.WriteLine("|");
            }
            Console.WriteLine();
            File.AppendAllText(filename, "\n");
        }


        int Solution(int[,] tMatrix)
        {
            return tMatrix[0, 0] * tMatrix[1, 1] - tMatrix[0, 1] * tMatrix[1, 0];
        }

        int SolutionMatrix(int[,] matrix)
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
                            smallMatrix[i, j - 1, (k < i ? k : k - 1)] = matrix[j, k];
                        }

                    }

                }
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
                File.AppendAllText(filename,  matrixMinor[i] + "* ");
                ShowMatrix(matrixM);
                int a = matrixMinor[i] * SolutionMatrix(matrixM);
                a = i % 2 == 0 ? a : (-1 * a);
                solution += a;
            }

            return solution;
        }
    }
}
