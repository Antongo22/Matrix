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
        double[,] matrix; // сама матрица
        double[] kramer; // массив для крамеров
        string filename = "data.txt"; // имя файла для записи

        public Matrix(double[,] matrix)
        {
            File.Create(filename).Close();
            this.matrix = matrix;

            ShowMatrix(matrix);
        }

        /// <summary>
        /// Вычисление определителя
        /// </summary>
        /// <exception cref="Exception">Ошибка того, что матрица может быть не равномерной</exception>
        public void CulcDeterminant()
        {          
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception("Матрица не одинаковых размеров!");
            }
            double solution = SolutionMatrix(matrix);
            Console.WriteLine(solution);
            File.AppendAllText(filename, "\n" + solution);
        }


        /// <summary>
        /// Вывод матрицы на экран
        /// </summary>
        /// <param name="matrix">Матрица для вывода</param>
        public void ShowMatrix(double[,] matrix)
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

        /// <summary>
        /// Вывод основной на экран
        /// </summary>
        /// <param name="matrix"></param>
        public void ShowMatrix()
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

        /// <summary>
        /// Вычисление матрицы 2 на 2
        /// </summary>
        /// <param name="tMatrix">сама матрица</param>
        /// <returns></returns>
        double Solution(double[,] tMatrix)
        {
            return tMatrix[0, 0] * tMatrix[1, 1] - tMatrix[0, 1] * tMatrix[1, 0];
        }

        /// <summary>
        /// Основное решение матрицы
        /// </summary>
        /// <param name="matrix">матрица для вычисления</param>
        /// <returns></returns>
        double SolutionMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) == 2)
            {
                return Solution(matrix);
            }

            double[] matrixMinor = new double[matrix.GetLength(0)];
            double[,] matrixM = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            double[,,] smallMatrix = new double[matrix.GetLength(0), matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            double solution = 0;

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
                double a = matrixMinor[i] * SolutionMatrix(matrixM);
                a = i % 2 == 0 ? a : (-1 * a);
                solution += a;
            }

            return solution;
        }

        /// <summary>
        /// Задаём крамеры
        /// </summary>
        /// <param name="arr"></param>
        public void SetKramer(params double[] arr)
        {
            kramer = arr;   
        }

        /// <summary>
        /// Копирование матрицы не по ссылке
        /// </summary>
        /// <returns></returns>
        double[,] NewMatrix()
        {
            double[,] newMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Вычисление крамера
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Kramer()
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception("Матрица не одинаковых размеров!");
            }
            double d;
            double[] delt = new double[matrix.GetLength(0)];
           
            d = SolutionMatrix(matrix);
            if (d == 0.0f)
            {
                Console.WriteLine("Дельта равна 0, решений нет");
                return;
            }

            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                double[,] newMatrix = NewMatrix();

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

        double this[int i, int j]
        {
            get => matrix[i, j];
            set => matrix[i, j] = value;
        }

        /// <summary>
        /// Получение длины матрицы
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        int GetLength(int num)
        {
            return matrix.GetLength(num);
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if(matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new Exception("Матрицы не одинаковых размеров!");
            }

            double[,] newMatrix = new double[matrix1.GetLength(0), matrix1.GetLength(1)];

            for(int i = 0;i < newMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return new Matrix(newMatrix);
        }

        public static Matrix operator *(Matrix matrix1, int num)
        {
            double[,] newMatrix = new double[matrix1.GetLength(0), matrix1.GetLength(1)];

            for(int i = 0;  i < newMatrix.GetLength(0); i++)
            {
                for(int j = 0;j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix1[i, j] * num;
                }
            }

            return new Matrix(newMatrix);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new Exception("Матрицы не подходят для умножения!");
            }

            int rows = matrix1.GetLength(0);
            int cols = matrix2.GetLength(1);
            int commonDimension = matrix1.GetLength(1);

            double[,] newMatrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < commonDimension; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    newMatrix[i, j] = sum;
                }
            }

            return new Matrix(newMatrix); 
        }

        public double[,] FindT()
        {
            return new double[0, 0];
        }
    }
}
