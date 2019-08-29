using System;
using Antlr4.Runtime;

namespace STtoKVScript
{
    public static class STtoKVScriptCore
    {
        public static string Execute(string input)
        {
            var inputStream = CharStreams.fromstring(input);
            var lexer = new STGrammerLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new STGrammerParser(tokenStream);

            var inputTree = parser.input();

            var (isSuccess, value) = new InterpreterImpl().Visit(inputTree);


            return value as string;
        }
    }
}
