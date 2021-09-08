using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Debug
{
    class Debug
    {
        [TestCaseSource(nameof(DivideCases))]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        static object[] DivideCases =
        {
        new object[] { 12, 3, 4 },
        new object[] { 12, 2, 6 },
        new object[] { 12, 4, 3 },
        new object[] { 16, 4, 4 }
    };
    }
}
