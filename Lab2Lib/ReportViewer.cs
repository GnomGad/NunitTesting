using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Lib
{
    public class ReportViewer
    {
        public int BlockCount { get; private set; } = 0;
        public int UsedSize { get; private set; } = 0;

        private IFileService _file;

        public ReportViewer()
        {
           _file = new FileService();
        }

        /// <summary>
        /// Этот метод должен сразу прекратить выполнение,если количество учтенных файлов было равно нулю
        /// Как это понимать? программа дальше не пойдет, дальше конец и все, смерть
        /// </summary>
        /// <param name="path"></param>
        public void PrepareDate(string path)
        {
            int result = _file.MergeTemporaryFiles(path);
            if (result == 0)
                return;
            BlockCount = result;
        }

        public void Clean(string path)
        {
            int result = 0;
            try
            {
                UsedSize = _file.RemoveTemporaryFiles(path);
            }
            catch
            {
                return;
            }
        }
    }
}
