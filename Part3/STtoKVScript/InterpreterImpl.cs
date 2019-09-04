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

        public override Result VisitExpr_stlang([NotNull] STGrammerParser.Expr_stlangContext context) => Visit(context.stlang());
        public override Result VisitExpr_expr([NotNull] STGrammerParser.Expr_exprContext context)
        {
            var ret = Visit(context.expr());
            var strRet = ret.Info as string;
            if(!ret.IsSuccess) {
                return new Result(false, "parse false");
            }
     
            return new Result(true, context.IDENTIFIER() + "=" + strRet);
        }

        public override Result VisitDefine([NotNull] STGrammerParser.DefineContext context)
        {
            return new Result(true, context.GetText());
        }

        public override Result VisitExpr_additive([NotNull] STGrammerParser.Expr_additiveContext context)
        {
            string lStr = Visit(context.lhs).Info as string;
            string rStr = (Visit(context.rhs).Info) as string;
            string test = context.op.Text;

            return new Result(true, lStr + test + rStr);
        }

        public override Result VisitExpr_define([NotNull] STGrammerParser.Expr_defineContext context)
        {
            return new Result(true, context.GetText());
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