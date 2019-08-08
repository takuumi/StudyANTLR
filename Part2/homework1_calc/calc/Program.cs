using System;
using Antlr4.Runtime;

namespace calc
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var inputStream = CharStreams.fromstring("10-34");
            var lexer = new calcLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new calcParser(tokenStream);

            var inputTree = parser.input();

            var (isSuccess, value) = new Visitor().Visit(inputTree);
            if (isSuccess) Console.WriteLine($"success. {value}");
            else Console.WriteLine("error.");
        }
    }
}
