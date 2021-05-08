using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Lib
{
    public class ReportViewer
    {
        public int BlockCount { get; private set; }
        public int UsedSize { get; private set; }
        public IFileService FS { get; private set; }

        public ReportViewer()
        {
           FS = new FileService();
        }

        /// <summary>
        /// Этот метод должен сразу прекратить выполнение,если количество учтенных файлов было равно нулю
        /// Как это понимать? программа дальше не пойдет, дальше конец и все, смерть
        /// </summary>
        /// <param name="path"></param>
        public void PrepareDate(string path)
        {
            int result = FS.MergeTemporaryFiles(path);
            if (result == 0)
                return;
            BlockCount = result;
        }

        public void Clean(string path)
        {
            try
            {
                UsedSize = FS.RemoveTemporaryFiles(path);
            }
            catch
            {
            }
        }
    }
}
