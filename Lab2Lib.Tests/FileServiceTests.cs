using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using Lab2Lib.Tests.Mocks;

namespace Lab2Lib.Tests
{
    [TestFixture]
    class FileServiceTests
    {
        string _path;

        FileService _fileService ;

        MockFileSystemObject _mockFileSystemObject;

        [OneTimeSetUp]
        public void Setup()
        {
            _path = Path.Combine("C:", "Lab2", "Tests");
        }

        [SetUp]
        public void Init()
        {
            _mockFileSystemObject = new MockFileSystemObject();
            _fileService = new FileService(_mockFileSystemObject);
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

        [Test]
        public void FileService_MergeTemporaryFiles_ExsistsWasCalled()
        {
            _fileService.MergeTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.ExsistsWasCalled);
        }

        [Test]
        public void FileService_MergeTemporaryFiles_GetFilesWasCalled()
        {
            _fileService.MergeTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.GetFilesWasCalled);
        }

        [Test]
        public void FileService_MergeTemporaryFiles_GetFileDataWasCalled()
        {
            _fileService.MergeTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.GetFileDataWasCalled);
        }
    
        [Test]
        public void FileService_MergeTemporaryFiles_DeleteFileWasCalled()
        {
            _fileService.MergeTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.DeleteFileWasCalled);
        } 

        [Test]
        public void FileService_MergeTemporaryFiles_CreateFileWasCalled()
        {
            _fileService.MergeTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.CreateFileWasCalled);
        }

        [Test]
        public void FileService_RemoveTemporaryFiles_ExsistsWasCalled()
        {
            _fileService.RemoveTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.ExsistsWasCalled);
        }

        [Test]
        public void FileService_RemoveTemporaryFiles_FileSizeWasCalled()
        {
            _fileService.RemoveTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.FileSizeWasCalled);
        }

        [Test]
        public void FileService_RemoveTemporaryFiles_DeleteFileWasCalled()
        {
            _fileService.RemoveTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.DeleteFileWasCalled);
        }

        [Test]
        public void FileService_RemoveTemporaryFiles_ReadLinesWasCalled()
        {
            _fileService.RemoveTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.ReadLinesWasCalled);
        }

        [Test]
        public void FileService_RemoveTemporaryFiles_CreateFileWasCalled()
        {
            _fileService.RemoveTemporaryFiles(_path);
            Assert.IsTrue(_mockFileSystemObject.CreateFileWasCalled);
        }
    }
}
