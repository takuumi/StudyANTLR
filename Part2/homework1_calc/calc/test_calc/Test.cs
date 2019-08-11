using NUnit.Framework;
using System;
namespace test_calc
{
    [TestFixture()]
    public class Test
    {
        [TestCase("11+1"            , "IntNumber:12")]            
        [TestCase("1+1.0"           , "RealNumber:2")]
        [TestCase("1 + .7"          , "RealNumber:1.7")]
        [TestCase("1 + 3."          , "RealNumber:4")]
        [TestCase("1.123+1.0"       , "RealNumber:2.123")]
        [TestCase("2147483647+1"    , "Err.OverFlow")]

        [TestCase("1-21"            , "IntNumber:-20")]
        [TestCase("1.0 - 1"         , "RealNumber:0")]
        [TestCase("1.0 - 1.123"     , "RealNumber:-0.123")]
        [TestCase("-2147483647-2"   , "Err.OverFlow")]

        [TestCase("11*1"            , "IntNumber:11")]
        [TestCase("11*0.1"          , "RealNumber:1.1")]
        [TestCase("2147483647*3"    , "Err.OverFlow")]
        [TestCase("2147483647*1"    , "IntNumber:2147483647")]

        [TestCase("10/2"            , "IntNumber:5")]
        [TestCase("11/2"            , "RealNumber:5.5")]
        [TestCase("10/0"            , "Err.ZeroDiv")]

        [TestCase("1+sin(90)"       , "RealNumber:2")]
        [TestCase("1+sin(180)"       , "RealNumber:1")]
        public void TestCase(string input, string expected)
        {
            Assert.AreEqual(expected, calc.Calclator.Execute(input));
        }
    }
}
