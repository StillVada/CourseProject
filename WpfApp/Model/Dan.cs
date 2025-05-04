using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Dan
    {
        public double iStart;
        public double iEnd;
        public double hstep;
        public double epsilon;
        public double gstep;
        public int dimension;
        public int precision;
        public double[] arrayA;
        public double[] controlArray;
        public double[,] arrayB;
        public double[] arrayC;
        public double[,] arrayY;
        public double[,] sortedArrayY;
        public Dan(double iStart, double iEnd, double hstep, double epsilon, double gstep)
        {
            this.iStart = iStart;
            this.iEnd = iEnd;
            this.hstep = hstep;
            this.epsilon = epsilon;
            this.gstep = gstep;
            this.dimension = (int)Math.Ceiling(((iEnd - iStart) / hstep)) + 1; // Размерность массивов
            this.precision = (int)Math.Ceiling(-Math.Log10(epsilon)); // Точность округления
        }
    }
}
