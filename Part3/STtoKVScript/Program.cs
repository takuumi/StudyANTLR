using System;

namespace STtoKVScript
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //string str = "CASE A OF \n B:\n C: D:= E; \n END_CASE; \n CASE A OF \n B, C: \n D..E: \n F,G,H..I:J:= K;\nEND_CASE;";
            string str = "A:= INT#10;";
            Console.WriteLine(STtoKVScriptCore.Execute(str));
        }
    }
}
