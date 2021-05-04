using NUnit.Framework;
using System;


namespace Lab1Lib.Tests
{
    [TestFixture,  Description("Покрытие тестами класса треугольника")]
    public class TriangleTests
    {
        Triangle triangle;

        [OneTimeSetUp]
        public void Init()
        {
            triangle = new Triangle(3, 4, 5);
        }

        [Description("При отрицательном числе должна вылетать FormatException")]
        [TestCase(-3, 4, 5)]
        [TestCase(3, -4, 5)]
        [TestCase(3, 4, -5)]
        public void SetSides_NegativeNum_FormatException(double a,double b, double c)
        {
            Assert.Throws<FormatException>(
                () => triangle.SetSides(a, b, c));
        }

        [Description("Конструктор класса использует метод SetSides, при отрицательном числе должна вылетать FormatException")]
        [TestCase(-3, 4, 5)]
        [TestCase(3, -4, 5)]
        [TestCase(3, 4, -5)]
        public void TriangleConstructor_NegativeNum_FormatException(double a, double b, double c)
        {
            Assert.Throws<FormatException>(
                () => triangle = new Triangle(a, b, c));
        }

        [Description("Тест на ошибку ArgumentException при несуществующем треугольнике")]
        [TestCase(1, 2, 7)]
        [TestCase(1, 7, 2)]
        [TestCase(7, 2, 1)]
        public void SetSides_NotCorrectTriangle_ArgumentException(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(
                () => triangle.SetSides(a, b, c));
        }

        [Description("Задан существующий треугольник, не должно происходить ошибок")]
        [TestCase(2, 3, 4)]
        [TestCase(2, 4, 3)]
        [TestCase(3, 4, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(3, 5, 3)]
        [TestCase(3, 1, 3)]
        public void SetSides_CorrectTriangle_DoesNotThrow(double a, double b, double c)
        {
            Assert.DoesNotThrow(() => triangle.SetSides(a, b, c));
        }

        [Description("На вход идут стороны существующего треугольника, на выходе площадь с погрешностью в 0.001")]
        [TestCase(2, 3, 4, 2.905)]
        [TestCase(2, 4, 3, 2.905)]
        [TestCase(3, 4, 2, 2.905)]
        [TestCase(1, 2, 3, 0.0)]
        [TestCase(3, 5, 3, 4.146)]
        [TestCase(3, 1, 3, 1.479)]
        public void Area_SetTriangle_AreaResulted(double a, double b, double c, double res)
        {
            triangle.SetSides(a, b, c);
            Assert.AreEqual(triangle.Area(), res, 0.001);
        }

    }
}