using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Lab1Lib.Tests
{
    [TestFixture, Description("Покрытие тестами класса системы линейных уравнений")]
    class LinearEquationsSystemTests
    {
        static object[] NotCorrectSizeMatrix =
        {
            new double[,] { { 1}, { 1} },
            new double[,] { { 12, 3 }, { 4,2 } },
            new double[,] {{5,3},{1,5}, { 1, 5 } , { 1, 5 } , { 1, 5 } }
        };
        static object[] CorrectSizeMatrix =
        {
            new double[,] { { 1, 1,5 }, { 1,1,3 } },
            new double[,] { { 12, 3,1 }, { 4,2,6 } },
            new double[,] {{5,3,1,4},{1,5,2,3}, { 1, 5,5,1 } }
        };
        static object[] ZeroDeterminantMatrix =
{
            new double[,] { { 1, 1,3 }, { 1,1,1 } },
            new double[,] { { 5, 5,5,2 }, { 5, 5,5,5 },{ 5, 5,5,8 }, },
        };

        LinearEquationsSystem linear;

        [SetUp]
        public void Setup()
        {
            linear = new LinearEquationsSystem();
        }

        [Description("Задан неправильная матрица, исходя из этого должна происходить ошибка")]
        [TestCaseSource(nameof(NotCorrectSizeMatrix))]
        public void SetCoefficients_NotCorrectSizeMatrix_FormatException(double[,] d)
        {
            Assert.Throws<FormatException>(() => { linear.SetCoefficients(d); });
        }

        [Description("Задан неправильная матрица, исходя из этого должна происходить ошибка")]
        [TestCaseSource(nameof(NotCorrectSizeMatrix))]
        public void LinearEquationsSystemConstructor_NotCorrectSizeMatrix_FormatException(double[,] d)
        {
            Assert.Throws<FormatException>(() => { linear = new LinearEquationsSystem(d); });
        }

        [Description("Задан матрица с нулевым определителем, исходя из этого должна происходить ошибка")]
        [TestCaseSource(nameof(ZeroDeterminantMatrix))]
        public void SetCoefficients_ZeroDeterminantMatrix_ArgumentException(double[,] d)
        {
            var l = new LinearEquationsSystem();
            Assert.Throws<ArgumentException>(() => { l.SetCoefficients(d); });
        }

        [Description("3х3 Матрица и её решение")]
        [Test]
        public void Solve_3x3Matrix_Solved()
        {
            double[,] c = { { 2, 2, 2, 20 }, { 4, 6, 2, 40 }, { 4, 16, 26, 72 } };
            double[] a = { (double)138 / 17, (double)16 / 17, (double)16 / 17 };
            linear.SetCoefficients(c);
            CollectionAssert.AreEqual(linear.Solve(), a);
        }

        [Description("2х2 Матрица и её решение")]
        [Test]
        public void Solve_2x2Matrix_Solved()
        {
            double[,] c = { { 2, 4, 2 }, { 2, 6, 4 } };
            double[] a = { -1, 1 };
            linear.SetCoefficients(c);
            CollectionAssert.AreEqual(linear.Solve(), a);
        }
    }
}
