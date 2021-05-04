using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Lab1Lib.Tests
{
    class StringFormatterTests
    {
        StringFormatter formatter;

        [SetUp]
        public void Setup()
        {
            formatter = new StringFormatter();
        }

        [Test, Description("При передаче null должна произойти ошибка NullReferenceException")]
        public void SafeString_NullString_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(
                () => formatter.SafeString(null));
        }

        [Test, Description("При передаче null должна произойти ошибка NullReferenceException")]
        public void WebString_NullString_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(
                () => formatter.WebString(null));
        }

        [Test, Description("При передаче null должна произойти ошибка NullReferenceException")]
        public void ShortFileString_NullString_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(
                () => formatter.ShortFileString(null));
        }

        [TestCase("'select Password from Users were login='admin''",
            ExpectedResult = "''SELECT Password from Users were login=''admin''''")]
        public string SafeString_String_CorrectReturned(string s)
        {
            return formatter.SafeString(s);
        }

        [TestCase("https://github.com/GnomGad/NunitTesting",
            ExpectedResult = "https://github.com/GnomGad/NunitTesting")]
        [TestCase("https://github.com/GnomGad/NunitTesting.git",
            ExpectedResult = "git://https://github.com/GnomGad/NunitTesting.git")]
        [TestCase("github.com/GnomGad/NunitTesting.git",
            ExpectedResult = "git://http://github.com/GnomGad/NunitTesting.git")]
        [TestCase("github.com/GnomGad/NunitTesting",
            ExpectedResult = "http://github.com/GnomGad/NunitTesting")]
        public string WebString_String_CorrectReturned(string s)
        {
            return formatter.WebString(s);
        }

        [TestCase("C:/Users/Professional/source/git/SoftDevCourse/Spring/Labs/Lab1.pdf",
    ExpectedResult = "LAB1.TMP")]
        [TestCase("C:/Users/Professional/source/git/SoftDevCourse/Spring/Labs/MegaLab",
    ExpectedResult = "MEGALAB.TMP")]
        public string ShortFileString_String_CorrectReturned(string s)
        {
            return formatter.ShortFileString(s);
        }

        [TestCase("",ExpectedResult ="")]
        public string SafeString_EmptyString_EmpryStringReturned(string s)
        {
            return formatter.SafeString(s);
        }
        [TestCase("", ExpectedResult = "")]
        public string WebString_EmptyString_EmpryStringReturned(string s)
        {
            return formatter.SafeString(s);
        }
        [TestCase("", ExpectedResult = "")]
        public string ShortFileString_EmptyString_EmpryStringReturned(string s)
        {
            return formatter.SafeString(s);
        }
    }
}
