using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1Lib
{
    public class StringFormatter
    {
        private void IfNullThrowException(string s)
        {
            if (s is null)
            {
                throw new NullReferenceException("string is null");
            }
        }
        public string SafeString(string s)
        {
            IfNullThrowException(s);

            s = s.Replace("'", "''");
            s = s.Replace("select", "SELECT").Replace("update", "UPDATE").Replace("delete", "DELETE").Replace("insert", "INSERT");

            return s;
        }

        public string WebString(string s)
        {
            IfNullThrowException(s);

            if (!s.Contains("://"))
            {
                s = "http://" + s;
            }

            if (s.EndsWith(".git"))
            {
                s = "git://" + s;
            }

            return s;
        }

        public string ShortFileString(string s)
        {
            IfNullThrowException(s);

            string name = Path.GetFileNameWithoutExtension(s);
            
            return name.ToUpper() + ".TMP";
        }
    }
}
