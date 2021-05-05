using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Lib
{
    public class StubFileService : IFileService
    {
        public int MergeTemporaryFiles(string dir) => 5;

        public int RemoveTemporaryFiles(string dir) => 5;
    }
}
