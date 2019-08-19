using System;
using Antlr4.Runtime;

namespace plcsim
{
    public static class PLCSimulator
    {
        // PLC環境とニモニック を引数に結果を出力する関数
        public static string Execute(Plc plc , string input)
        {
            var inputStream = CharStreams.fromstring(input);
            var lexer = new plcsimLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new plcsimParser(tokenStream);

            var inputTree = parser.input();

            var (isSuccess, value) = new InterpreterImpl(plc).Visit(inputTree);

            if (isSuccess) return "Success:" + $"{value}";
            else
            {
                return "Err";
            }
        }
    }
}

