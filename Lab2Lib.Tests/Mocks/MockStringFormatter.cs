using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2Lib.Tests.Mocks
{
    public class MockStringFormatter : Lab2Lib.StringFormatter.IStringFormatter
    {
        public bool SafeStringWasCalled { get; private set; }
        public string SafeString(string s)
        {
            SafeStringWasCalled = true;
            return "mock";
        }
    }
}
