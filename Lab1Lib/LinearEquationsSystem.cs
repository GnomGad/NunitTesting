using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Lib
{
    public class LinearEquationsSystem
    {
        private double[,] _matrix;

        public LinearEquationsSystem()
        {

        }

        /// <summary>
        /// Параметризованный конструктор
        /// </summary>
        /// <param name="coeffs">массив [n,n], где n == 2 || n == 3</param>
        public LinearEquationsSystem(double[,] coeffs)
        {
            SetCoefficients(coeffs);
        }

        public void SetCoefficients(double[,] coeffs)
        {
            if (!IsCorrectSize(coeffs))
                throw new FormatException("Bad size");// размерность непонятная

            if (MatrixDeterminant(coeffs) == (double)0)
                throw new ArgumentException("Zero determinant");

            _matrix = coeffs;

        }

        /// <summary>
        /// Проверка размера массива
        /// </summary>
        /// <param name="coeffs"></param>
        /// <returns>true если верно</returns>
        public bool IsCorrectSize(double[,] coeffs)
        {
            if ((coeffs.GetLength(0) == 2 && coeffs.GetLength(1) == 3) ||(coeffs.GetLength(0) == 3 && coeffs.GetLength(1) == 4))
                return true;

            return false;
        }

        /// <summary>
        /// Просчет детерминанта матрицы
        /// </summary>
        /// <param name="coeffs"></param>
        /// <returns></returns>
        public double MatrixDeterminant(double[,] coeffs)
        {
            if (coeffs.Length == 6)
                return coeffs[0, 0] * coeffs[1, 1] - coeffs[0, 1] * coeffs[1, 0];

            return (coeffs[0, 0] * coeffs[1, 1] * coeffs[2, 2]
           + coeffs[1, 0] * coeffs[2, 1] * coeffs[0, 2]
           + coeffs[0, 1] * coeffs[1, 2] * coeffs[2, 0]
           - coeffs[0, 2] * coeffs[1, 1] * coeffs[2, 0]
           - coeffs[0, 0] * coeffs[2, 1] * coeffs[1, 2]
           - coeffs[0, 1] * coeffs[1, 0] * coeffs[2, 2]);
        }


        public double[] Solve()
        {
            return Gauss(_matrix);
        }

        /// <summary>
        /// Метод гаусса взят с википедии
        /// </summary>
        /// <param name="Matrix"></param>
        /// <returns></returns>
        public double[] Gauss(double[,] Matrix)
        {
            int n = Matrix.GetLength(0); //Размерность начальной матрицы (строки)
            double[,] Matrix_Clone = new double[n, n + 1]; //Матрица-дублер
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n + 1; j++)
                    Matrix_Clone[i, j] = Matrix[i, j];

            //Прямой ход (Зануление нижнего левого угла)
            for (int k = 0; k < n; k++) //k-номер строки
            {
                for (int i = 0; i < n + 1; i++) //i-номер столбца
                    Matrix_Clone[k, i] = Matrix_Clone[k, i] / Matrix[k, k]; //Деление k-строки на первый член !=0 для преобразования его в единицу
                for (int i = k + 1; i < n; i++) //i-номер следующей строки после k
                {
                    double K = Matrix_Clone[i, k] / Matrix_Clone[k, k]; //Коэффициент
                    for (int j = 0; j < n + 1; j++) //j-номер столбца следующей строки после k
                        Matrix_Clone[i, j] = Matrix_Clone[i, j] - Matrix_Clone[k, j] * K; //Зануление элементов матрицы ниже первого члена, преобразованного в единицу
                }
                for (int i = 0; i < n; i++) //Обновление, внесение изменений в начальную матрицу
                    for (int j = 0; j < n + 1; j++)
                        Matrix[i, j] = Matrix_Clone[i, j];
            }

            //Обратный ход (Зануление верхнего правого угла)
            for (int k = n - 1; k > -1; k--) //k-номер строки
            {
                for (int i = n; i > -1; i--) //i-номер столбца
                    Matrix_Clone[k, i] = Matrix_Clone[k, i] / Matrix[k, k];
                for (int i = k - 1; i > -1; i--) //i-номер следующей строки после k
                {
                    double K = Matrix_Clone[i, k] / Matrix_Clone[k, k];
                    for (int j = n; j > -1; j--) //j-номер столбца следующей строки после k
                        Matrix_Clone[i, j] = Matrix_Clone[i, j] - Matrix_Clone[k, j] * K;
                }
            }

            //Отделяем от общей матрицы ответы
            double[] Answer = new double[n];
            for (int i = 0; i < n; i++)
                Answer[i] = Matrix_Clone[i, n];

            return Answer;
        }
    }
}
