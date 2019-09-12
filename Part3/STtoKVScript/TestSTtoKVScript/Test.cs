﻿using NUnit.Framework;
using STtoKVScript;
using System;

namespace TestSTtoKVScript
{
    [TestFixture()]
    public class Test
    {
        [TestCase("//hogehoge \n //hugahuga", "'hogehoge \n'hugahuga\n")]
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

            string expect1 = "A=#1\n";
            string expect2 = "A=#1.0\n";
            string expect3 = "A=\"ABC\"\n'シングルクォートがマルチバイト文字列\n";
            string expect4 = "A=\"ABC\"\n'ダブルクォートがワイド文字列\n";


            var result1 = STtoKVScriptCore.Execute(input1);
            var result2 = STtoKVScriptCore.Execute(input2);
            var result3 = STtoKVScriptCore.Execute(input3);
            var result4 = STtoKVScriptCore.Execute(input4);
            Assert.AreEqual(expect1, result1);
            Assert.AreEqual(expect2, result2);
            Assert.AreEqual(expect3, result3);
            Assert.AreEqual(expect4, result4);

        }

        [TestCase()]
        public void TestCaseE2()
        {
            string input1 = "A:= INT#10;";
            string input2 = "A:= UINT#10;";
            string input3 = "A:= LREAL#1.0;";
            string input4 = "A:= STRING#'ABC';";

            string expect1 = "A=TOS(#10)\n";
            string expect2 = "A=TOU(#10)\n";
            string expect3 = "A=TODF(#1.0)\n";
            string expect4 = "A=\"ABC\"\n";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            var result2 = STtoKVScriptCore.Execute(input2);
            var result3 = STtoKVScriptCore.Execute(input3);
            var result4 = STtoKVScriptCore.Execute(input4);


            Assert.AreEqual(expect1, result1);
            Assert.AreEqual(expect2, result2);
            Assert.AreEqual(expect3, result3);
            Assert.AreEqual(expect4, result4);

        }

        [TestCase()]
        public void TestCaseE3()
        {
            string input1 = "A:= 2#1001_0110;";
            string input2 = "A:= 8#1024;";
            string input3 = "A:= 16#ABCD;";

            string expect1 = "A=$96\n";
            string expect2 = "A=#532\n";
            string expect3 = "A=$ABCD\n";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            var result2 = STtoKVScriptCore.Execute(input2);
            var result3 = STtoKVScriptCore.Execute(input3);

            Assert.AreEqual(expect1, result1);
            Assert.AreEqual(expect2, result2);
            Assert.AreEqual(expect3, result3);
        }

        [TestCase()]
        public void TestCaseE4()
        {
            string input1 = "A := UINT#2#1100_0011;";
            string expect1 = "A=TOU($c3)\n";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            Assert.AreEqual(expect1, result1);
        }

        [TestCase()]
        public void TestCaseE5()
        {
            string input1 = "A := B + C --D * E / F MOD G ** H;";
            string expect1 = "A=B+C--D*E/F MOD G^H\n";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            Assert.AreEqual(expect1, result1);
        }

        [TestCase()]
        public void TestCaseE6()
        {
            string input1 = "A := NOT B AND C OR D XOR E & F;";
            string expect1 = "A=NOT(B AND C OR D XOR E AND F)\n";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            Assert.AreEqual(expect1, result1);
        }

        [TestCase()]
        public void TestCaseE7()
        {
            string input1 = "A := B<C> D <= E >= F;";
            string expect1 = "A=B<C>D<=E>=F\n";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            Assert.AreEqual(expect1, result1);
        }

        [TestCase()]
        public void TestCaseE8()
        {
            string input1 = "A := B = C<> D;";
            string expect1 = "A=B=C<>D\n";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            Assert.AreEqual(expect1, result1);
        }

        [TestCase()]
        public void TestCaseE9()
        {
            string input1 = "FUNC();";
            string input2 = "A := FUNC(B);";
            string input3 = "A := FUNC(B AND C, D = E);";
            string input4 = "A := FUNC(B := C);";
            string input5 = "A := FUNC(B, C => D);";

            string expect1 = "FUNC()\n";
            string expect2 = "A=FUNC(B)\n";
            string expect3 = "A=FUNC(B AND C,D=E)\n";
            string expect4 = "A=FUNC(B:=C)\n";
            string expect5 = "A=FUNC(B,C:=D)";

            var result1 = STtoKVScriptCore.Execute(input1);

            Console.WriteLine(result1);

            var result2 = STtoKVScriptCore.Execute(input2);
            var result3 = STtoKVScriptCore.Execute(input3);
            var result4 = STtoKVScriptCore.Execute(input4);
            var result5 = STtoKVScriptCore.Execute(input5);


            Assert.AreEqual(expect1, result1);
            Assert.AreEqual(expect2, result2);
            Assert.AreEqual(expect3, result3);
            Assert.AreEqual(expect4, result4);
            Assert.AreEqual(expect5, result5);

        }
    }
}
