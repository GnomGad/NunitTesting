using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2Lib.Tests.Mocks
{
    public class MockFilseService : IFileService
    {
        public bool MergeTemporaryFilesWasCalled { get; private set; }
        public bool RemoveTemporaryFilesWasCalled { get; private set; }

        public int MergeTemporaryFiles(string dir)
        {
            MergeTemporaryFilesWasCalled = true;
            return 0;
        }

        public int RemoveTemporaryFiles(string dir)
        {
            RemoveTemporaryFilesWasCalled = true;
            return 0;
        }
    }
}
