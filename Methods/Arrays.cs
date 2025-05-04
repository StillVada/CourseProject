using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Logic
{
    public static class Arrays
    {

        /// <summary>
        /// Создание массива A
        /// </summary>
        public static double[] MakeArrayA(double iStart, double iEnd, double hstep, double epsilon, int dimension, int precision)
        {
            double[] A = new double[dimension];

            int arrayIndex = 0;

            if (hstep > 0) // Проверка на ввод отрицательного начального значения шага
            {
                for (double i = iStart; i <= iEnd; i += hstep)
                {
                    A[arrayIndex] = Math.Round(SeriesCalc.SeriesSum(i, epsilon), precision); // Заполнение массива A с округлением до точности epsilon
                    arrayIndex++;
                }
            }
            else
            {
                for (double i = iStart; i >= iEnd; i += hstep)
                {
                    A[arrayIndex] = Math.Round(SeriesCalc.SeriesSum(i, epsilon), precision); // Заполнение массива A с округлением до точности epsilon
                    arrayIndex++;
                }
            }
            return A;
        }

        /// <summary>
        /// Создание массива контрольных сумм
        /// </summary>
        public static double[] MakeControlArray(double iStart, double iEnd, double hstep, double epsilon, int dimension, int precision)
        {
            double[] checkSums = new double[dimension];

            int arrayIndex = 0;

            if (hstep > 0) // Проверка на ввод отрицательного начального значения шага
            {
                for (double i = iStart; i <= iEnd; i += hstep)
                {
                    checkSums[arrayIndex] = Math.Round(SeriesCalc.FormularCheck(i), precision); // Заполнение массива контрольных сумм
                    arrayIndex++;
                }
            }
            else
            {
                for (double i = iStart; i >= iEnd; i += hstep)
                {
                    checkSums[arrayIndex] = Math.Round(SeriesCalc.FormularCheck(i), precision); // Заполнение массива контрольных сумм
                    arrayIndex++;
                }
            }
            return checkSums;
        }

        /// <summary>
        /// Создание массива B
        /// </summary>
        public static double[,] MakeArrayB(int dimension)
        {
            double[,] B = new double[dimension, dimension];
            int value = 1;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = dimension -1 ; j >= 0; j--)
                {
                    B[i, j] = value;
                    value++;
                }
            }
            return B;
        }
        /// <summary>
        /// Создание массива C путём перемножения одномерного и двумерного массива и домножения на 2
        /// </summary>
        public static double[] MakeArrayC(double[] A, double[,] B)
        {
            int size = A.Length;
            double[] C = new double[size];

            C = MultiplyMatrix(A, TransposeMatrix(B));

            return C;
        }

        private static double[,] TransposeMatrix(double[,] Matrix)
        {

            int n = Matrix.GetLength(0);
            double[,] transposedMatrix = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    transposedMatrix[j, i] = Matrix[i, j];
                }
            }

            return transposedMatrix;
        }

        private static double[] MultiplyMatrix(double[] A, double[,] B)
        {
            int dimension = A.Length;
            double[] TempMatrix = new double[dimension];
            for (int i = 0; i < dimension; i++)
            {
                double result = 0;
                for (int j = 0; j < dimension; j++)
                {
                    result += A[j] * B[j, i];
                }
                TempMatrix[i] = result;
            }
            return TempMatrix;
        }

        /// <summary>
        /// Создание массива Y
        /// </summary>
        public static double[,] MakeArrayY(double[] C, double gstep)
        {
            double[] X = new double[C.Length];
            for (int j = 0; j < X.Length; j++)
            {
                X[j] = j;
            }
            double[] coefficient = Coefficient(X, C);
            double xMax = X.Max();
            double xMin = X.Min();

            List<double[]> listY = new List<double[]>(); 
            double i = xMin;

            while (i <= xMax)
            {
                double y = coefficient[0];
                for (int j = 1; j < coefficient.Length; j++)
                {
                    y += coefficient[j] * Math.Pow(i, j);
                }

                listY.Add(new double[] { i, y }); 

                i += gstep; 
            }

            double[,] Y = new double[listY.Count, 2];
            for (int k = 0; k < listY.Count; k++)
            {
                Y[k, 0] = listY[k][0];
                Y[k, 1] = listY[k][1];
            }

            return Y;
        }

        public static double[,] MethodGauss(double[,] Y, double[] C, ref double[] X)
        {
            double max;
            double sum;
            double[] Cnew = new double[C.Length];
            C.CopyTo(Cnew, 0);
            for (int k = 0; k < Y.GetLength(0); k++)
            {
                for (int i = k + 1; i < Y.GetLength(1); i++)
                {
                    max = Y[i, k] / Y[k, k];
                    for (int j = k; j < Y.GetLength(1); j++)
                    {
                        Y[i, j] = Y[i, j] - (max * Y[k, j]);
                    }
                    Cnew[i] = Cnew[i] - max * Cnew[k];
                }
            }
            for (int i = Y.GetLength(0) - 1; i >= 0; i--)
            {
                sum = 0;
                for (int j = i + 1; j < Y.GetLength(0); j++)
                {
                    sum += Y[i, j] * X[j];
                }
                X[i] = (Cnew[i] - sum) / Y[i, i];
            }
            return Y;
        }

        public static double[] Coefficient(double[] X, double[] C)
        {
            double[,] Y = new double[X.Length, X.Length];
            for (int i = 0; i < Y.GetLength(0); i++)
            {
                for (int j = 0; j < Y.GetLength(0); j++)
                {
                    if (j == 0)
                    {
                        Y[i, j] = 1;
                    }
                    else if (j == 1)
                    {
                        Y[i, j] = X[i];
                    }
                    else
                    {
                        Y[i, j] = Math.Pow(X[i], j);
                    }
                }
            }
            double[] coefficient = new double[C.Length];
            MethodGauss(Y, C, ref coefficient);
            return coefficient;
        }
        public static double[,] ShellSort(double[,] matrix)
        {
            int n = matrix.GetLength(0); 

            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    double firstElement = matrix[i, 0];
                    double secondElement = matrix[i, 1];

                    int j;
                    for (j = i; j >= gap && matrix[j - gap, 1] > secondElement; j -= gap)
                    {
                        matrix[j, 0] = matrix[j - gap, 0];
                        matrix[j, 1] = matrix[j - gap, 1];
                    }

                    matrix[j, 0] = firstElement;
                    matrix[j, 1] = secondElement;
                }

                gap /= 2;
            }
            return matrix;
        }

    }
}
