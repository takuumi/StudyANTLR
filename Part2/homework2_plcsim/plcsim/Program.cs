using System;
using System.Diagnostics;

namespace plcsim
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var plc = new Plc();
            plc.BitDevices["R0"] = true;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM1"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, "LD R0\nMOV DM0 DM1"));
            Debug.Assert(10 == plc.WordDevices["DM1"]);
        }
    }
}
