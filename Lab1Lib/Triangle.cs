using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Lib
{
    public class Triangle
    {
        private double _a, _b, _c;

        public Triangle(double a, double b, double c)
        {
            SetSides(a, b, c);
        }
        /// <summary>
        /// Вычислить площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double Area() 
        {
            double p = (_a + _b + _c) / 2;
            double s = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            return s;
        }

        public void SetSides(double a,double b, double c)
        {
            if (IsNegative(a) || IsNegative(b) || IsNegative(c))
                throw new FormatException("Одна из сторон отрицательна");

            if (IsNotTreangle(a, b, c) || IsNotTreangle(a, c, b) || IsNotTreangle(b, c, a))
                throw new ArgumentException("Такой треугольник невозможен");

            _a = a;
            _b = b;
            _c = c;
        }

        public bool IsNegative(double x) => x < 0;

        public bool IsNotTreangle(double a1, double a2, double x) => (a1 + a2) < x;
    }
}
