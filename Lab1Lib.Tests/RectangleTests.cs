using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Lab1Lib.Tests
{
    [TestFixture, Description("Покрытие тестами класса квадрата")]
    class RectangleTests
    {
        Rectangle rectangle;

        [OneTimeSetUp]
        public void Init()
        {
            rectangle = new Rectangle();
        }

        [Description("Заданы координаты точек, что не образуют прямоугольника ArgumentException")]

        [TestCase(new double[] { -10, -10, 0, 0 }, new double[] { 5, 1, 1, 1 })]
        [TestCase(new double[] { -10, 0, 0, 0 }, new double[] { 5, 2, 1, 1 })]
        [TestCase(new double[] { 0, 0, 0, 0 }, new double[] { 0, 0, 0, 0 })]
        public void SetVertices_NotCorrectRectangle_ArgumentException(double[] x, double[] y)
        {
            Assert.Throws<ArgumentException>(
                () => rectangle.SetVertices(x,y));
        }

        [Description("Конструктор класса использует метод SetNegative, при отрицательном числе должна вылетать ArgumentException")]
        [TestCase(new double[] { -10, -10, 0, 0 }, new double[] { 5, 1, 1, 1 })]
        [TestCase(new double[] { -10, 0, 0, 0 }, new double[] { 5, 2, 1, 1 })]
        [TestCase(new double[] { 0, 0, 0, 0 }, new double[] { 0, 0, 0, 0})]
        public void RectangleConstructor_NotCorrectRectangle_ArgumentException(double[] x, double[] y)
        {
            Assert.Throws<ArgumentException>(
                () => rectangle = new Rectangle(x,y));
        }

        [Description("Задан существующий прямоугольник, не должно происходить ошибок")]
        [TestCase(new double[] { 0, 10, 10, 0 }, new double[] { 0, 0, -10, -10 })]
        [TestCase(new double[] { -10, -10, 0, 0 }, new double[] { 5, 1, 1, 5 })]
        public void SetVertices_CorrectRectangle_DoesNotThrow(double[] x, double[] y)
        {
            Assert.DoesNotThrow(() => rectangle.SetVertices(x,y));
        }

        [Description("На вход идут вершины прямоугольника, а на выход диагональ с погрешностью в 0.001")]
        [TestCase(new double[] { 0, 10, 10, 0 }, new double[] { 0, 0, -10, -10 },14.142)]
        [TestCase(new double[] { -10, -10, 0, 0 }, new double[] { 5, 1, 1, 5 },10.770)]
        public void Diagonal_SetRectangle_DiagonalResulted(double[] x, double[] y,double res)
        {
            rectangle.SetVertices(x, y);
            Assert.AreEqual(rectangle.Diagonal(), res,0.001);
        }
    }
}
