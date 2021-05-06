using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Lab2Lib.Tests
{
    [TestFixture]
    class FileServiceTests
    {
        FileService fs;

        [OneTimeSetUp]
        public void Init()
        {
            fs = new FileService();
        }

        [Test, Description("При передаче null аргумента, одна выскакивать ошибка")]
        public void MergeTemporaryFiles_NullArgument_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => fs.MergeTemporaryFiles(null));
        }
    }
}
