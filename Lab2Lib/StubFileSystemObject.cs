using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab2Lib
{
    public class StubFileSystemObject: IFileSystemObject
    {
        private readonly string[] _dirs;
        private readonly string[] _files;
        private readonly byte[][] _data;
        private const int _fileCounter = 3;

        private readonly string _toRemove;
        private readonly string[] _toRemoveData;
        
        public StubFileSystemObject()
        {
            string path = Path.Combine("C:", "Lab2", "Tests");
            _dirs = new [] { Path.Combine("C:", "Lab2", "Tests"), Path.Combine("C:") };
            _files = new string[_fileCounter] { "File1.tmp", "File2.tmp", "File3.tmp" };
            _data = new byte[_fileCounter][] {
                Encoding.UTF8.GetBytes("s12312ad"),
                Encoding.UTF8.GetBytes("baasdasd"),
                Encoding.UTF8.GetBytes("ssdasdad") };
            _toRemove = Path.Combine("C:", "Lab2", "Tests","ToRemove.txt");
            _toRemoveData = new string[_fileCounter+1] { 
                Path.Combine(path,_files[0]), 
                Path.Combine(path, _files[1]), 
                Path.Combine(path, _files[2]),
                "Hello.txt"};
        }
        public bool Exsists(string path)
        {
            if (path == "Hello.txt")
            {
                return false;
            }

            foreach(string d in _dirs)
            {
                if (d == path)
                {
                    return true;
                }
            }

            foreach (string f in _files)
            {
                if (f == path)
                {
                    return true;
                }
            }

            foreach (string f in _toRemoveData)
            {
                if (f == path)
                {
                    return true;
                }
            }

            if (path == _toRemove)
            {
                return true;
            }

            return false;
        }

        public string[] GetFiles(string path)
        {
            if (path == Path.Combine("C:", "Lab2", "Tests"))
            {
                return _files;
            }
            return new string[] { };
        }

        public byte[] GetFileData(string file)
        {
            for(int i = 0; i < _fileCounter; i++)
            {
                if (_files[i] == file)
                {
                    return _data[i];
                }
            }
            return null;
        }

        public bool DeleteFile(string file)
        {
            for (int i = 0; i < _fileCounter; i++)
            {
                if (_files[i] == Path.GetFileName(file))
                {
                    _data[i] = null;
                    _files[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool CreateFile(string name, byte[] data)
        {
            for (int i = 0; i < _fileCounter; i++)
            {
                if (_files[i] == name)
                {
                    return false;
                }
            }
            return true;
        }

        public int FileSize(string name)
        {
            for (int i = 0; i < _fileCounter; i++)
            {
                if (_files[i] == Path.GetFileName(name))
                {
                    return _files[i].Length;
                }
            }
            return 0;
        }

        public string[] ReadLines(string name)
        {
            if(_toRemove == name)
            {
                return _toRemoveData;
            }

            return null;
        }
    }
}
