using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Lib
{
    public interface IFileSystemObject
    {
        /// <summary>
        /// Проверка на существования файла или папки
        /// </summary>
        /// <param name="path">путь к  файлу или папке</param>
        /// <returns></returns>
        bool Exsists(string path);

        /// <summary>
        /// Получить имена файлов
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string[] GetFiles(string path);

        /// <summary>
        /// Получить контекст файла
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        byte[] GetFileData(string file);

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool DeleteFile(string path);

        /// <summary>
        /// Создать файл и заполнить его байтами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool CreateFile(string name, byte[] data);

        /// <summary>
        /// Вернуть размер файла
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int FileSize(string name);

        /// <summary>
        /// Читает файл
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string[] ReadLines(string name);
    }
}
