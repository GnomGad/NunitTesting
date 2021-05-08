using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace Lab2Lib.Tests
{
    [TestFixture]
    class FileServiceTests
    {
        string _path;

        [OneTimeSetUp]
        public void Init()
        {
            _path = Path.Combine("C:", "Lab2", "Tests");
        }

        [Test]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_3()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            int count = f.MergeTemporaryFiles(_path);

            Assert.AreEqual(count, 3);
        }
        [Test]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_0()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            int count = f.MergeTemporaryFiles(Path.Combine("C:"));

            Assert.AreEqual(count, 0);
        }

        [Test]
        public void FileServiceConstructorInjection_FileSystemObjectIsNull_ArgumentNullException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f;

            Assert.Throws<ArgumentNullException>(() => f = new FileService(null));
        }

        [Test]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_ArgumentNullException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<ArgumentNullException>(() => f.MergeTemporaryFiles(null));
        }

        [Test]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_DirectoryNotFoundException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<DirectoryNotFoundException>(() => f.MergeTemporaryFiles("D:\\Stab\\123213"));
        }

        [Test]
        public void FileServiceProperyInjection_MergeTemporaryFiles_3()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService();
            f.FileSystem = fs;

            int count = f.MergeTemporaryFiles(_path);

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void FileServiceProperyInjection_FileSystemObjectIsNull_ArgumentNullException()
        {
            FileService f = new FileService();

            Assert.Throws<ArgumentNullException>(() => f.FileSystem = null);
        }

        [Test]
        public void FileServiceProperyInjection_StubFileSystemObject_GetStubFileSystemObject()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService();
            f.FileSystem = fs;

            Assert.AreEqual(f.FileSystem, fs);
        }

        [Test]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_ArgumentNullException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<ArgumentNullException>(() => f.RemoveTemporaryFiles(null));
        }

        [Test]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_DirectoryNotFoundException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<DirectoryNotFoundException>(() => f.RemoveTemporaryFiles("D:\\Stab\\123213"));
        }

        [Test]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_FileNotFoundException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<FileNotFoundException>(() => f.RemoveTemporaryFiles("C:"));
        }

        [Test]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_3()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            int count = f.RemoveTemporaryFiles(_path);

            Assert.AreEqual(count, 27);
        }
    }
}
