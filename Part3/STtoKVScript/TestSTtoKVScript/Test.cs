using NUnit.Framework;
using STtoKVScript;
using System;

namespace TestSTtoKVScript
{
    [TestFixture()]
    public class Test
    {
        [TestCase("//hogehoge \n //hugahuga", ";hogehoge \n;hugahuga\n")]
        public void TestCaseLineComment(string input, string expected)
        {
            var result = STtoKVScriptCore.Execute(input);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }

        [TestCase("hoge := DM0 + 1;", "hoge=DM0+1\n")]
        public void TestCaseNoarmalDevice(string input, string expected)
        {
            var result = STtoKVScriptCore.Execute(input);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }

    }
}
