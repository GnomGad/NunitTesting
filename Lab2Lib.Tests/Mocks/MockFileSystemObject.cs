using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2Lib.Tests.Mocks
{
    public class MockFileSystemObject : IFileSystemObject
    {
        public bool CreateFileWasCalled { get; private set; }
        public bool DeleteFileWasCalled { get; private set; }
        public bool ExsistsWasCalled { get; private set; }
        public bool FileSizeWasCalled { get; private set; }
        public bool GetFileDataWasCalled { get; private set; }
        public bool GetFilesWasCalled { get; private set; }
        public bool ReadLinesWasCalled { get; private set; }

        public bool CreateFile(string name, byte[] data)
        {
            CreateFileWasCalled = true;
            return true;
        }

        public bool DeleteFile(string path)
        {
            DeleteFileWasCalled = true;
            return true;
        }

        public bool Exsists(string path)
        {
            ExsistsWasCalled = true;
            return true;
        }

        public int FileSize(string name)
        {
            FileSizeWasCalled = true;
            return 1;
        }

        public byte[] GetFileData(string file)
        {
            GetFileDataWasCalled = true;
            return new byte[] { };
        }

        public string[] GetFiles(string path)
        {
            GetFilesWasCalled = true;
            return new string[] { "File1.tmp", "File2.tmp", "File3.tmp" };
        }

        public string[] ReadLines(string name)
        {
            ReadLinesWasCalled = true;
            return new string[] { "ssssss", "Hello.txt" };
        }
    }
}
