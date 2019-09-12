using System;

namespace STtoKVScript
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string str = "A := UINT#2#1100_0011;";
//            string str = "hoge := DM0 + 1";
            Console.WriteLine(STtoKVScriptCore.Execute(str));
        }
    }
}
