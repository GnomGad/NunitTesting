using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2Lib.StringFormatter
{
    public class StringFormatter : IStringFormatter
    {
        public string SafeString(string s) => new Lab1Lib.StringFormatter().SafeString(s);
    }
}
