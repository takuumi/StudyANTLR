using Antlr4.Runtime.Misc;

namespace STtoKVScript
{
    class InterpreterImpl : STGrammerBaseVisitor<InterpreterImpl.Result>
    {
        public InterpreterImpl()
        {
        }

        public override Result VisitInput([NotNull] STGrammerParser.InputContext context)
        {
            string str = "";
            foreach (var e in context.oneline())
            {
                var ret = Visit(e);
                if (!ret.IsSuccess) return ret;
                str += ret.Info as string;
                str += "\n";
            }
            return new Result(true, str);
        }

        public override Result VisitExpr_stlinecomment([NotNull] STGrammerParser.Expr_stlinecommentContext context)
        {
            // 適当実装
            return new Result(true, context.GetText().Replace("//", ";"));
        }

        // 結果クラス
        public class Result
        {
            public Result(bool isSuccess, object info)
            {
                IsSuccess = isSuccess;
                Info = info;
            }

            public void Deconstruct(out bool isSuccess, out object info)
            {
                isSuccess = IsSuccess;
                info = Info;
            }
            public bool IsSuccess { get; }
            public object Info { get; }
        }

    }
}