using System;
using Antlr4.Runtime;

namespace plcsim
{
    public static class PLCSimulator
    {
        public static string Execute(Plc plc , string input)
        {
            var inputStream = CharStreams.fromstring(input);
            var lexer = new plcsimLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new plcsimParser(tokenStream);

            var inputTree = parser.input();

            var (isSuccess, value) = new Visitor(plc).Visit(inputTree);
            // TODO
            if (isSuccess) return ":" + $"{value}";
            else
            {
                return "Err";
            }
        }
    }
}
