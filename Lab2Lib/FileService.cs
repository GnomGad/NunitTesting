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

        public int MergeTemporaryFiles(string dir)
        {
            IfNullThrowException(dir);
            IfDirectoryNotFoundThrowException(dir);

            string[] files = Directory.GetFiles(dir, "*.tmp");//получить данные

            if (files.Length == 0)
                return 0;

            object[] buff = GetContentFiles(files);
            DeleteFiles(files);
            CreateBackup(Path.Combine(dir, NameBackup), buff);

            return files.Length;
        }
        public int RemoveTemporaryFiles(string dir)
        {
            IfNullThrowException(dir);
            IfDirectoryNotFoundThrowException(dir);

            string toRemoveFile = "ToRemove.txt";
            string pathToRemoveFile = Path.Combine(dir, Path.Combine(dir, toRemoveFile));

            if (!File.Exists(pathToRemoveFile))
            {
                throw new FileNotFoundException($"Файл {toRemoveFile} не найден");
            }

            string[] res = Encoding.UTF8.GetString(getContentFile(pathToRemoveFile)).Split('\n');
            return 0;
        }

        private void IfNullThrowException(string dir)
        {
            if (dir is null)
                throw new NullReferenceException("string is null");
        }

        private void IfDirectoryNotFoundThrowException(string dir)
        {
            if (!Directory.Exists(dir))
                throw new DirectoryNotFoundException($"Директория по пути {dir} не найдена");
        }

        void CreateBackup(string dir, object[] buff)
        {
            using (FileStream fstream = File.Create(dir))
            {
                foreach (byte[] b in buff)
                {
                    fstream.Write(b, 0, b.Length);
                }
            }
        }

        object[] GetContentFiles(string[] files)
        {
            object[] obj = new object[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                obj[i] = getContentFile(files[i]);
            }
            return obj;
        }

        byte[] getContentFile(string file)
        {
            byte[] array;
            using (FileStream fstream = File.OpenRead(file))
            {
                array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
            }
            return array;
        }

        void DeleteFiles(string[] files)
        {
            foreach (string s in files)
            {
                DeleteFile(s);
            }
        }

        void DeleteFile(string file) => File.Delete(file);
    }
}
