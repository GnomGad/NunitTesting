using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab2Lib
{
    public class FileService: IFileService
    {
        public readonly string NameBackup = "backup.tmp";
        public readonly string ToRemove = "ToRemove.txt";
        public readonly string ErrorLog = "error.log";
        private IFileSystemObject _fs;
        
        public FileService()
        {
            _fs = new StubFileSystemObject();
        }

        public FileService(IFileSystemObject fs)
        {
            if(fs is null)
            {
                throw new ArgumentNullException("Передан null");
            }
            _fs = fs;
        }

        public IFileSystemObject FileSystem
        {
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("Передан null");
                }
                _fs = value;
            }
            get
            {
                return _fs;
            }
        }

        public int MergeTemporaryFiles(string dir)
        {
            IfNullThrowException(dir);
            IfDirectoryNotFoundThrowException(dir);

            string[] files = _fs.GetFiles(dir);//получить данные

            if (files.Length == 0)
                return 0;

            byte[][] buff = GetContentFiles(files);
            DeleteFiles(files);
            CreateBackup(Path.Combine(dir, NameBackup), buff);
            return files.Length;
        }

        public int RemoveTemporaryFiles(string dir)
        {
            IfNullThrowException(dir);
            IfDirectoryNotFoundThrowException(dir);

            string pathToRemove = Path.Combine(dir, ToRemove);

            if (!_fs.Exsists(pathToRemove))
                throw new FileNotFoundException($"Файл {ToRemove} не найден");

            List<string> err = new List<string>();

            string[] lines = _fs.ReadLines(pathToRemove);
            int sizes = 0;
            foreach (string s in lines)
            {
                if (!_fs.Exsists(s))
                {
                    err.Add($"Файл {s} не найден\r\n");
                    continue;
                }

                sizes += _fs.FileSize(s);
                _fs.DeleteFile(s);
            }

            _fs.CreateFile(Path.Combine(dir, ErrorLog), Encoding.UTF8.GetBytes(String.Join("", err.ToArray())));

            return sizes;
        }
        private void IfNullThrowException(string dir)
        {
            if (dir is null)
                throw new NullReferenceException("string is null");
        }

        private void IfDirectoryNotFoundThrowException(string dir)
        {
            if (!_fs.Exsists(dir))
                throw new DirectoryNotFoundException($"Директория по пути {dir} не найдена");
        }

        void CreateBackup(string dir, byte[][] buff)
        {
            int bytes = 0;
            for(int i =0;i< buff.Length; i++)
            {
                bytes += buff[i].Length;
            }
            byte[] b = new byte[bytes];
            for (int i = 0,counter =0; i < buff.Length; i++)
            {
                for (int j = 0; j<buff[i].Length; j++, counter++)
                {
                    b[counter] = buff[i][j];
                }
            }
            _fs.CreateFile(dir, b);
        }

        byte[][] GetContentFiles(string[] files)
        {
            byte[][] obj = new byte[files.Length][];
            for (int i = 0; i < files.Length; i++)
            {
                obj[i] = getContentFile(files[i]);
            }
            return obj;
        }

        byte[] getContentFile(string file)
        {
            return _fs.GetFileData(file);
        }

        void DeleteFiles(string[] files)
        {
            foreach (string s in files)
            {
                DeleteFile(s);
            }
        }

        void DeleteFile(string file) => _fs.DeleteFile(file);
    }
}
