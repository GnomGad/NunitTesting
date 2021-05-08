using NUnit.Framework;
using System;
using System.IO;

namespace Lab2Lib.Tests
{
    public class ReportViewerTests
    {
        private string _path;

        [OneTimeSetUp]
        public void Setup()
        {
            _path = Path.Combine("C:", "Lab2", "Tests");
        }

        [Test]
        public void ReportViewer_PrepareDate_3()
        {
            ReportViewer rv = new ReportViewer();

            rv.PrepareDate(_path);

            Assert.AreEqual(rv.BlockCount, 3);
        }

        [Test]
        public void ReportViewer_PrepareDate_0()
        {
            ReportViewer rv = new ReportViewer();

            rv.PrepareDate(Path.Combine("C:"));

            Assert.AreEqual(rv.BlockCount, 0);
        }

        [Test]
        public void ReportViewer_Clean_27()
        {
            ReportViewer rv = new ReportViewer();

            rv.Clean(_path);

            Assert.AreEqual(rv.UsedSize, 27);
        }

        [Test]
        public void ReportViewer_Clean_0()
        {
            ReportViewer rv = new ReportViewer();

            rv.Clean(Path.Combine("C:","add"));

            Assert.AreEqual(rv.UsedSize, 0);
        }
    }
}