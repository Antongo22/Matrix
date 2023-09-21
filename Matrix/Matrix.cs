using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matrix
    {
        int[,] matrix;
        int[] kramer;
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
                int a = matrixMinor[i] * SolutionMatrix(matrixM);
                a = i % 2 == 0 ? a : (-1 * a);
                solution += a;
            }

            return solution;
        }

        public void SetKramer(int[] arr)
        {
            kramer = arr;   
        }

        int[,] NewMatrix()
        {
            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            return newMatrix;
        }

        public void Kramer()
        {
            float d;
            int[] delt = new int[matrix.GetLength(0)];
           
            d = SolutionMatrix(matrix);
            if (d == 0.0f)
            {
                Console.WriteLine("Дельта равна 0, решений нет");
                return;
            }

            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                int[,] newMatrix = NewMatrix();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[j, i] = kramer[j];
                }
                delt[i] = SolutionMatrix(newMatrix);
           
            }

            for(int i = 0; i < delt.Length; i++)
            {
                File.AppendAllText(filename, $"\n{delt[i] / d}");
                Console.WriteLine(delt[i] / d);
            }
        }
    }
}
