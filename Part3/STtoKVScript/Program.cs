using System;

namespace STtoKVScript
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string str = "hoge := DM0 + 1";
            Console.WriteLine(STtoKVScriptCore.Execute(str));
        }
    }
}
