using System;


namespace calc
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            object ftest = float.Parse("1.0");
            float hoge = (float)ftest;

            object itest = int.Parse("1");
            float huga = (float)(int)itest;



            Console.WriteLine("Hello World!");
            Console.WriteLine(Calclator.Execute("1+1.0"));

        }
    }
}
