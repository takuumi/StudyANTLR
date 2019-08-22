using System;
using NUnit.Framework;
using plcsim;
namespace test_plcsim
{
    [TestFixture()]
    public class Test
    {
        [TestCase("LD R0\nMOV DM0 DM10", 10)]
        public void TestCaseNormal(string input, int expected)
        {
            var plc = new Plc();
            plc.BitDevices["R0"] = true;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM10"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, input));
            Assert.AreEqual(expected, plc.WordDevices["DM10"]);
        }

        [TestCase("LD R0\nMOV DM0 DM10", 0)]
        public void TestCaseExecuteConditionOFF(string input, int expected)
        {
            var plc = new Plc();
            plc.BitDevices["R0"] = false;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM10"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, input));
            Assert.AreEqual(expected, plc.WordDevices["DM10"]);
        }

        [TestCase("LD R0\nMOV.U DM0 DM10", 10)]
        public void TestCaseNormalSuffixU(string input, int expected)
        {
            var plc = new Plc();
            plc.BitDevices["R0"] = true;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM10"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, input));
            Assert.AreEqual(expected, plc.WordDevices["DM10"]);
        }

        [TestCase("LD R0\nMOV.D DM0 DM10", 10, 3)]
        public void TestCaseNormalSuffixD(string input, int expected1, int expected2)
        {
            var plc = new Plc();
            plc.BitDevices["R0"] = true;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM1"] = 3;
            plc.WordDevices["DM10"] = 0;
            plc.WordDevices["DM11"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, input));
            Assert.AreEqual(expected1, plc.WordDevices["DM10"]);
            Assert.AreEqual(expected2, plc.WordDevices["DM11"]);
        }

        [TestCase("LD R0\nMOV DM0 DM10:DM20", 10)]
        public void TestCaseIndexDevice(string input, int expected1)
        {
            Plc plc = new Plc();
            plc.BitDevices["R0"] = true;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM20"] = 3;
            plc.WordDevices["DM13"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, input));
            Assert.AreEqual(expected1, plc.WordDevices["DM13"]);
        }

        [TestCase("LD R0\nMOV.D DM0 DM10:DM20", 10, 5)]
        public void TestCaseIndexDeviceSuffixD(string input, int expected1, int expected2)
        {
            Plc plc = new Plc();
            plc.BitDevices["R0"] = true;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM1"] = 5;
            plc.WordDevices["DM20"] = 3;
            plc.WordDevices["DM13"] = 0;
            plc.WordDevices["DM14"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, input));
            Assert.AreEqual(expected1, plc.WordDevices["DM13"]);
            Assert.AreEqual(expected2, plc.WordDevices["DM14"]);

        }


    }


}
