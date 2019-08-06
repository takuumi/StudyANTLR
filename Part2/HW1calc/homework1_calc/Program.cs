using System;
using Antlr4.Runtime;

namespace homework1_calc
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            
            string parsedString = "hello abc";
            var inputStream = new AntlrInputStream(parsedString);
            var lexer = new calcLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new calcParser(commonTokenStream);
            var graphContext = parser.input();
            Console.WriteLine(graphContext.ToStringTree());
            

        }
    }
}
