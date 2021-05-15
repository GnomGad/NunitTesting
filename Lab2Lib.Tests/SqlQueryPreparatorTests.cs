using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SFormatter = Lab2Lib.StringFormatter.StringFormatter;
using SFormatterStub = Lab2Lib.StringFormatter.StubStringFormatter;


namespace Lab2Lib.Tests
{
    [TestFixture]
    public class SqlQueryPreparatorTests
    {

        readonly string[] _q = { "'select Password from Users were login='admin''",
                        "'select * from Users were login='admin''" };
        readonly string[] _qExpected = { "''SELECT Password from Users were login=''admin''''",
            "''SELECT * from Users were login=''admin''''"};
        readonly string[] _qExpectedStub = { "stub", "stub" };

        SqlQueryPreparator _sqp;

        [SetUp]
        public void Init()
        {
            _sqp = new SqlQueryPreparator();
        }

        /*
         * Внедрение через класс
         */

        [Test]
        public void SqlQueryPreparatorClassInjection_NullStringFormatter_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { _sqp = new SqlQueryPreparator(null); });
        }

        [Test]
        public void SqlQueryPreparatorClassInjection_PrepareQueries_SafeStrings()
        { 
            _sqp = new SqlQueryPreparator(new SFormatter());
            string[] res =_sqp.PrepareQueries(_q);
            CollectionAssert.AreEqual(res, _qExpected);
        }

        [Test]
        public void SqlQueryPreparatorClassInjection_PrepareQueries_NullReferenceException()
        {
            _sqp = new SqlQueryPreparator(new SFormatter());
            Assert.Throws<NullReferenceException>(() => _sqp.PrepareQueries(null));
        }

        [Test]
        public void SqlQueryPreparatorClassInjection_PrepareQueries_StubSafeStrings()
        {
            _sqp = new SqlQueryPreparator(new SFormatterStub());
            string[] res = _sqp.PrepareQueries(_q);
            CollectionAssert.AreEqual(res, _qExpectedStub);
        }


        /*
         * Внедрение через Свойство
         */

        [Test]
        public void SqlQueryPreparatorPropertiesjection_NullStringFormatter_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { _sqp.SF = null; });
        }

        [Test]
        public void SqlQueryPreparatorPropertiesjection_PrepareQueries_SafeStrings()
        {
            _sqp.SF = new SFormatter();
            string[] res = _sqp.PrepareQueries(_q);
            CollectionAssert.AreEqual(res, _qExpected);
        }

        [Test]
        public void SqlQueryPreparatorPropertiesInjection_PrepareQueries_NullReferenceException()
        {
            _sqp.SF = new SFormatter();
            Assert.Throws<NullReferenceException>(() => _sqp.PrepareQueries(null));
        }

        [Test]
        public void SqlQueryPreparatorPropertiesInjection_PrepareQueries_StubSafeStrings()
        {
            _sqp.SF = new SFormatterStub();
            string[] res = _sqp.PrepareQueries(_q);
            CollectionAssert.AreEqual(res, _qExpectedStub);
        }
    }
}
