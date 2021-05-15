using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using Lab2Lib.Tests.Mocks;
using Moq;

namespace Lab2Lib.Tests
{
    [TestFixture]
    class FileServiceTests
    {
        string _path;

        FileService _fileService ;
        MockFileSystemObject _mockFileSystemObject;

        Mock<IFileSystemObject> _mock;
        FileService _fileS;

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

            _mock = new Mock<IFileSystemObject>();
            _fileS = new FileService(_mock.Object);
        }

        /*
         * Стаб тесты с инъекцией через Конструктор
         */

        [Test, Description("Наличие файлов")]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_3()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            int count = f.MergeTemporaryFiles(_path);

            Assert.AreEqual(count, 3);
        }
        [Test, Description("Файлы отстутствуют")]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_0()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            int count = f.MergeTemporaryFiles(Path.Combine("C:"));

            Assert.AreEqual(count, 0);
        }

        [Test, Description("Передать в конструктор null")]
        public void FileServiceConstructorInjection_FileSystemObjectIsNull_ArgumentNullException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f;

            Assert.Throws<ArgumentNullException>(() => f = new FileService(null));
        }

        [Test, Description("Передать в метод null")]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_ArgumentNullException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<ArgumentNullException>(() => f.MergeTemporaryFiles(null));
        }

        [Test, Description("Указать несуществующую папку")]
        public void FileServiceConstructorInjection_MergeTemporaryFiles_DirectoryNotFoundException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<DirectoryNotFoundException>(() => f.MergeTemporaryFiles("D:\\Stab\\123213"));
        }

        /*
         * Стаб тест с инъекцией через свойство
         */

        [Test, Description("Существующий путь с файлами")]
        public void FileServiceProperyInjection_MergeTemporaryFiles_3()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService();
            f.FileSystem = fs;

            int count = f.MergeTemporaryFiles(_path);

            Assert.AreEqual(count, 3);
        }

        [Test, Description("Указать через свойство null")]
        public void FileServiceProperyInjection_FileSystemObjectIsNull_ArgumentNullException()
        {
            FileService f = new FileService();

            Assert.Throws<ArgumentNullException>(() => f.FileSystem = null);
        }

        [Test, Description("Удостоверится, что объект переданный через свойство тот же")]
        public void FileServiceProperyInjection_StubFileSystemObject_GetStubFileSystemObject()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService();
            f.FileSystem = fs;

            Assert.AreSame(f.FileSystem, fs);
        }

        [Test, Description("Передать null в метод")]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_ArgumentNullException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<ArgumentNullException>(() => f.RemoveTemporaryFiles(null));
        }

        [Test, Description("Указать несуществующую папку")]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_DirectoryNotFoundException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<DirectoryNotFoundException>(() => f.RemoveTemporaryFiles("D:\\Stab\\123213"));
        }

        [Test, Description("Указать путь в котором нет файлов")]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_FileNotFoundException()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            Assert.Throws<FileNotFoundException>(() => f.RemoveTemporaryFiles("C:"));
        }

        [Test, Description("Указать путь с файлами")]
        public void FileServiceConstructorInjection_RemoveTemporaryFiles_3()
        {
            IFileSystemObject fs = new StubFileSystemObject();
            FileService f = new FileService(fs);

            int count = f.RemoveTemporaryFiles(_path);

            Assert.AreEqual(count, 27);
        }

        /*
         * Рукописные мок тесты  MergeTemporaryFiles
         */

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

        /*
         * Рукописные мок тесты  RemoveTemporaryFiles
         */

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

        /*
         * Тестирование с моков помощью Moq 
         */

        [Test]
        public void FileService_MergeTemporaryFiles_Moq()
        {
            _mock.Setup(x => x.Exsists(It.IsAny<string>())).Returns(true);
            _mock.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(new string[]{ "File1.tmp", "File2.tmp", "File3.tmp" });
            _mock.Setup(x => x.GetFileData(It.IsAny<string>())).Returns(new byte[] { });
            _mock.Setup(x => x.DeleteFile(It.IsAny<string>())).Returns(true);
            _mock.Setup(x => x.CreateFile(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(true);

            _fileS.MergeTemporaryFiles(_path);

            _mock.VerifyAll();
        }

        [Test]
        public void FileService_RemoveTemporaryFiles_Moq()
        {
            _mock.Setup(x => x.Exsists(It.IsAny<string>())).Returns(true);
            _mock.Setup(x => x.ReadLines(It.IsAny<string>())).Returns(new string[] { "File1.tmp", "File2.tmp", "File3.tmp" });
            _mock.Setup(x => x.FileSize(It.IsAny<string>())).Returns(1);
            _mock.Setup(x => x.DeleteFile(It.IsAny<string>())).Returns(true);
            _mock.Setup(x => x.CreateFile(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(true);

            _fileS.RemoveTemporaryFiles(_path);

            _mock.VerifyAll();
        }
    }
}
