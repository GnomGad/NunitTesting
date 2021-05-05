using NUnit.Framework;
using System;
using System.IO;
namespace Lab2Lib.Tests
{
    public class ReportViewerTests
    {
        readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "TestLab2");

        [SetUp]
        public void Setup()
        {
        }

        [Test, Description("Тестирование стаба в конструкторе")]
        public void ReportViewerConstructorInjection_PrepareDate_5()
        {
            IFileService ifs = new StubFileService();
            ReportViewer rv = new ReportViewer(ifs);

            rv.PrepareDate(_path);

            Assert.AreEqual(rv.BlockCount, 5);
        }

        [Test, Description("Тестирование ReportViewer на null аргумент")]
        public void ReportViewerConstructorInjection_NullFileService_ArgumentNullException()
        {
            ReportViewer rv;

            Assert.Throws<ArgumentNullException>(() => rv = new ReportViewer(null));
        }

        [Test, Description("Тестирование стаба в свойстве")]
        public void ReportViewerProperyInjection_PrepareDate_5()
        {
            IFileService ifs = new StubFileService();
            ReportViewer rv = new ReportViewer();
            rv.File = ifs;

            rv.PrepareDate(_path);

            Assert.AreEqual(rv.BlockCount, 5);
        }

        [Test, Description("Тестирование ReportViewer на null аргумент в свойстве")]
        public void ReportViewerProperyInjection_NullFileService_ArgumentNullException()
        {
            ReportViewer rv = new ReportViewer();

            Assert.Throws<ArgumentNullException>(() => rv.File = null);
        }
    }
}