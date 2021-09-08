using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Debug
{
    class TestStrings
    {
        [TestCaseSource(nameof(TestString), new object[] { true })]
        public void LongNameWithEvenNumberOfCharacters(string name)
        {
            Assert.That(name.Length, Is.GreaterThan(5));
            bool hasEvenNumOfCharacters = (name.Length / 2) == 0;
        }

        [TestCaseSource(nameof(TestString), new object[] { false })]
        public void ShortName(string name)
        {
            Assert.That(name.Length, Is.LessThan(15));
        }

        static IEnumerable<string> TestString(bool generateLongTestCase)
        {
            if (generateLongTestCase)
                yield return "ThisIsAVeryLongNameThisIsAVeryLongName";
            yield return "SomeName";
            yield return "YetAnotherName";
        }
    }
}
