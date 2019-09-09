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

        [TestCase("hoge := DM0 + 1;", "hoge=DM0+#1\n")]
        public void TestCaseNoarmalDevice(string input, string expected)
        {
            var result = STtoKVScriptCore.Execute(input);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }

        [TestCase()]
        public void TestCaseE1()
        {
            string input1 = "A := 1;";
            string input2 = "A:= 1.0;";
            string input3 = "A:= 'ABC'; //シングルクォートがマルチバイト文字列";
            string input4 = "A:= \"ABC\"; //ダブルクォートがワイド文字列";

            string expect1 = "A = #1\n";
            string expect2 = "A = #1.0\n";
            string expect3 = "A = \"ABC\" 'シングルクォートがマルチバイト文字列\n";
            string expect4 = "A = \"ABC\" 'ダブルクォートがワイド文字列";

            var result1 = STtoKVScriptCore.Execute(input1);
            var result2 = STtoKVScriptCore.Execute(input2);
//            var result3 = STtoKVScriptCore.Execute(input3);
//            var result4 = STtoKVScriptCore.Execute(input4);
            Assert.AreEqual(result1, expect1);
            Assert.AreEqual(result2, expect2);
//            Assert.AreEqual(result3, expect3);
//            Assert.AreEqual(result4, expect4);

        }



    }
}
