using System;
using System.Diagnostics;

namespace plcsim
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Plc plc = new Plc();
            plc.BitDevices["R0"] = true;
            plc.WordDevices["DM0"] = 10;
            plc.WordDevices["DM20"] = 3;
            plc.WordDevices["DM13"] = 0;
            Console.WriteLine(PLCSimulator.Execute(plc, "LD R0\nMOV.D DM0 DM10:DM20"));
        }
    }
}
