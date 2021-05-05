using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Lab1Lib.Tests
{
    [TestFixture, Description("Тестирование")]
    class ArrayProcessorTests
    {
        ArrayProcessor array;
        [SetUp]
        public void Setup()
        {
            array = new ArrayProcessor();
        }

        [Test, Description("Отдать Негативный, получить позитивный ")]
        public void SortAndFilter_NegativeUnsorted_PositiveSorted()
        {
            double[] a = { 10, -5, 3, -8, 0 };
            double[] b = { 10, 5, 3, 8, 0 };
            CollectionAssert.AreEquivalent(array.SortAndFilter(a), b);
        }

        [Test, Description("Получить несортированный массив, отдать сортированный")]
        public void SortAndFilter_Unsorted_Sorted()
        {
            double[] a = { 10, -5, 3, -8, 0, 0, -5, 10, -8, 3, 3, 3, 3, 3, 3, 3 };
            double[] b = { 10, 5, 3, 8, 0 };
            CollectionAssert.AreEquivalent(array.SortAndFilter(a), b);
        }
    }
}
