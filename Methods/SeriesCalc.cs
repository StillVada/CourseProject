using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SeriesCalc
    {
        /// <summary>
        /// Вычисление суммы ряда с заданной точностью
        /// </summary>
        public static double SeriesSum(double x, double eps = 0.001)
        {
            double sum = 0;
            double currentElement = (2 * Math.Pow(x, 4 + 2)) / Factorial(2 + 1);
            int i = 1;
            int sign = 1;
            while (Math.Abs(currentElement) > eps)
            {
                sum += sign * currentElement;
                i++;
                sign *= -1;
                currentElement = (2 * i * Math.Pow(x, 4 * i + 2)) / Factorial(2 * i + 1); 
            }
            return sum;
        }

        public static double FormularCheck(double x)
        {
            double formular = Math.Sin(Math.Pow(x, 2)) - Math.Pow(x, 2) * Math.Cos(Math.Pow(x, 2));
            return formular;
        }

        private static double Factorial(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            double res = 1;
            for (int i = 1; i <= x; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}
