using System;
using Antlr4.Runtime;
using static calc.ErrString;

namespace calc
{
    public static class Calclator
    {
        public static string Execute(string input)
        {
            var inputStream = CharStreams.fromstring(input);
            var lexer = new calcLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new calcParser(tokenStream);

            var inputTree = parser.input();

            var (isSuccess, type, value) = new Visitor().Visit(inputTree);
            if (isSuccess) return $"{type}" + ":" + $"{value}";
            else
            {
                return ErrString.GetErrString((ErrID)value);

            }
        }
    }
}
