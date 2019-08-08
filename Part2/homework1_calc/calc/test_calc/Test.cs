using NUnit.Framework;
using System;
namespace test_calc
{
    [TestFixture()]
    public class Test
    {
        [TestCase("11+1" , "12")]            // +
        [TestCase("1-1"  , "0")]              
        [TestCase("1-21" , "-20")]           // -
        [TestCase("4-1"  , "3")]
        [TestCase("11*1", "11")]            // *
        [TestCase("10/2", "5")]           // -
        [TestCase("10/0", "err")]

        public void TestCase(string input, string expected)
        {
            Assert.AreEqual(expected, calc.Calclator.Execute(input));
        }
    }
}
