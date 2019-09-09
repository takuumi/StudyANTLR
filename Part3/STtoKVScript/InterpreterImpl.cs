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
            foreach (var e in context.block())
            {
                var ret = Visit(e);
                if (!ret.IsSuccess) return ret;
                str += ret.Info as string;
                str += "\n";
            }
            return new Result(true, str);
        }

        public override Result VisitSt_expression([NotNull] STGrammerParser.St_expressionContext context)
        {
            var ret = Visit(context.expr());
            var strRet = ret.Info as string;
            if (!ret.IsSuccess)
            {
                return new Result(false, "parse false");
            }

            return new Result(true, strRet);
        }

        public override Result VisitExpr_assign([NotNull] STGrammerParser.Expr_assignContext context)
        {
            string lStr = Visit(context.lhs).Info as string;
            string rStr = (Visit(context.rhs).Info) as string;
            return new Result(true, lStr + "=" + rStr);
        }


        public override Result VisitExpr_variable([NotNull] STGrammerParser.Expr_variableContext context)
        {
            return new Result(true, context.GetText());
        }

        public override Result VisitExpr_normal_value([NotNull] STGrammerParser.Expr_normal_valueContext context)
        {
            switch (context.Start.Type)
            {
                case STGrammerParser.NUM_UINT : return new Result(true, "#" + int.Parse(context.Start.Text).ToString());
                case STGrammerParser.NUM_REAL : return new Result(true, "#" + float.Parse(context.Start.Text).ToString());
                default: return DefaultResult;
            }
        }


        public override Result VisitExpr_additive([NotNull] STGrammerParser.Expr_additiveContext context)
        {
            string lStr = Visit(context.lhs).Info as string;
            string rStr = (Visit(context.rhs).Info) as string;
            string test = context.op.Text;

            return new Result(true, lStr + test + rStr);
        }

        public override Result VisitSt_linecomment([NotNull] STGrammerParser.St_linecommentContext context)
        {
            // 適当実装
            return new Result(true, context.GetText().Replace("//", "'"));
        }

        public override Result VisitExpr_multistring([NotNull] STGrammerParser.Expr_multistringContext context)
        {
            string str = Visit(context.expr()).Info as string;
            return new Result(true, "\"" + str + "\"");
        }

        public override Result VisitExpr_widestring([NotNull] STGrammerParser.Expr_widestringContext context)
        {
            string str = Visit(context.expr()).Info as string;
            return new Result(true, "\"" + str + "\"");
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