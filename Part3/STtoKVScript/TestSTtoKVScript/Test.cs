using NUnit.Framework;
using STtoKVScript;
using System;

namespace TestSTtoKVScript
{
    [TestFixture()]
    public class Test
    {
        [TestCase("//hogehoge \n //hugahuga", ";hogehoge\n;hugahuga")]
        public void TestCaseLineComment(string input, string expected)
        {
            var result = STtoKVScriptCore.Execute(input);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }
    }
}
