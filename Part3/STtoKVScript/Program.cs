using System;

namespace STtoKVScript
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string str = "//hogehoge \n //hugahuga";
            Console.WriteLine(STtoKVScriptCore.Execute(str));
        }
    }
}
