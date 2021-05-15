using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Lib.StringFormatter;

namespace Lab2Lib
{
    public class SqlQueryPreparator
    {
        public bool PrepareQueriesWasCalled { get; private set; } = false;

        private IStringFormatter _sf;

        public IStringFormatter SF
        {
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("Передан null");
                }
                _sf = value;
            }
            get
            {
                return _sf;
            }
        }

        public SqlQueryPreparator()
        {
            SF = new StringFormatter.StringFormatter();
        }
        public SqlQueryPreparator(IStringFormatter sf)
        {
            SF = sf;
        }

        public string[] PrepareQueries(string[] queries)
        {
            PrepareQueriesWasCalled = true;

            string[] safeQueries = new string[queries.Length];

            for (int i = 0; i < queries.Length; i++)
                safeQueries[i] = _sf.SafeString(queries[i]);

            return safeQueries;
        }
    }
}
