using System;
using System.Collections.Generic;
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

        /* repeat */
        public override Result VisitExpt_stblock_repeat([NotNull] STGrammerParser.Expt_stblock_repeatContext context)
        {
            string strRepeat = "DO\n";

            foreach (var e in context._blks)
            {
                string str = Visit(e).Info as string;
                strRepeat += str;
                strRepeat += "\n";
            }
            strRepeat += "UNTIL ";
            strRepeat += Visit(context.expr()).Info as string;

            return new Result(true, strRepeat);
        }

        /* return */
        public override Result VisitStatement_return([NotNull] STGrammerParser.Statement_returnContext context)
        {
            //todo
            return new Result(true, "IF FALSE THEN");
        }

        /* case */
        public override Result VisitStatement_case([NotNull] STGrammerParser.Statement_caseContext context)
        {
            string strCase = "SELECT CASE ";
            strCase += Visit(context.expr()).Info as string;

            strCase += "\nCASE ";
            foreach (var e in context._caseblk)
            {
                string str = Visit(e).Info as string;
                strCase += str;
            }

            if (context.else_block() != null)
            {
                strCase += "CASE ELSE\n";
                string str = Visit(context.else_block()).Info as string;
                strCase += str;
                strCase += "\n";
            }

            strCase += "END SELECT";
            return new Result(true, strCase);
        }

        public override Result VisitCase_block([NotNull] STGrammerParser.Case_blockContext context)
        {
            string strCase = "";

            int iCount = 0;
            foreach (var e in context._lbl)
            {                
                if(iCount != 0)
                {
                    strCase += ",";
                }
                string str = Visit(e).Info as string;
                strCase += str;
                iCount++;
            }
            strCase += "\n";

            foreach (var e in context._blk)
            {
                string str = Visit(e).Info as string;
                strCase += str;
            }
            strCase += "\n";

            return new Result(true, strCase);

        }

        public override Result VisitCase_label([NotNull] STGrammerParser.Case_labelContext context)
        {
            string strCase = Visit(context.case_cond(0)).Info as string;

            foreach (var e in context._cnd2)
            {
                strCase += ",";
                string str = Visit(e).Info as string;
                strCase += str;
            }

            return new Result(true, strCase);
        }

        public override Result VisitCase_cond([NotNull] STGrammerParser.Case_condContext context)
        {
            if (context.IDENTIFIER() != null)
            {
                if (context.RANGE() != null )
                {
                    return new Result(true, context.IDENTIFIER(0).GetText() + " TO " + context.IDENTIFIER(1).GetText());
                }
                return new Result(true, context.IDENTIFIER(0).GetText());

            } else
            { 
                string str = Visit(context.normal_value(0)).Info as string;
                if (context.RANGE() != null)
                {
                    string str1 = Visit(context.normal_value(1)).Info as string;
                    str = str + " TO " + str1;
                }
                return new Result(true, str);

            }

            return base.VisitCase_cond(context);
        }

        /*
                case_block: lbl+=case_label+ blk+=block*;
        case_cond
            : IDENTIFIER
            | IDENTIFIER RANGE IDENTIFIER
            | normal_value
            | normal_value RANGE normal_value
            ;
        else_block :ELSE blk+=block*;
        */

        /* expression */
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

        /* operation */
        public override Result VisitExpr_not([NotNull] STGrammerParser.Expr_notContext context)
        {
            string str = Visit(context.func_expr()).Info as string;
            return new Result(true, "NOT(" + str + ")");
        }

        public override Result VisitExpr_assign([NotNull] STGrammerParser.Expr_assignContext context)
        {
            string lStr = Visit(context.lhs).Info as string;
            string rStr = (Visit(context.rhs).Info) as string;
            return new Result(true, lStr + "=" + rStr);
        }

        public override Result VisitExpr_unary([NotNull] STGrammerParser.Expr_unaryContext context)
        {
            string str = Visit(context.expr()).Info as string;

            switch (context.op.Type)
            {
                case STGrammerParser.PLUS: return new Result(true, "+" + str);
                case STGrammerParser.MINUS: return new Result(true, "-" + str);
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

        public override Result VisitExpr_multipricative([NotNull] STGrammerParser.Expr_multipricativeContext context)
        {
            string strLhs = Visit(context.lhs).Info as string;
            string strRhs = Visit(context.rhs).Info as string;

            switch (context.op.Type)
            {
                case STGrammerParser.ASTERISK: return new Result(true, strLhs + "*" + strRhs);
                case STGrammerParser.SLASH: return new Result(true, strLhs + "/" + strRhs);
                case STGrammerParser.POW: return new Result(true, strLhs + "^" + strRhs);
                case STGrammerParser.MOD: return new Result(true, strLhs + " MOD " + strRhs);
                default: return DefaultResult;
            }
        }

        public override Result VisitExpr_logical_operation([NotNull] STGrammerParser.Expr_logical_operationContext context)
        {
            string strLhs = Visit(context.lhs).Info as string;
            string strRhs = Visit(context.rhs).Info as string;

            switch (context.op.Type)
            {
                case STGrammerParser.AND: return new Result(true, strLhs + " AND " + strRhs);
                case STGrammerParser.AND2: return new Result(true, strLhs + " AND " + strRhs);
                case STGrammerParser.OR: return new Result(true, strLhs + " OR " + strRhs);
                case STGrammerParser.XOR: return new Result(true, strLhs + " XOR " + strRhs);
                default: return DefaultResult;
            }

        }

        public override Result VisitExpr_comparison_operation([NotNull] STGrammerParser.Expr_comparison_operationContext context)
        {
            string strLhs = Visit(context.lhs).Info as string;
            string strRhs = Visit(context.rhs).Info as string;

            switch (context.op.Type)
            {
                case STGrammerParser.GT: return new Result(true, strLhs + ">" + strRhs);
                case STGrammerParser.GE: return new Result(true, strLhs + ">=" + strRhs);
                case STGrammerParser.LT: return new Result(true, strLhs + "<" + strRhs);
                case STGrammerParser.LE: return new Result(true, strLhs + "<=" + strRhs);
                default: return DefaultResult;
            }
        }

        public override Result VisitExpr_equivalent_operation([NotNull] STGrammerParser.Expr_equivalent_operationContext context)
        {
            string strLhs = Visit(context.lhs).Info as string;
            string strRhs = Visit(context.rhs).Info as string;

            switch (context.op.Type)
            {
                case STGrammerParser.EQ: return new Result(true, strLhs + "=" + strRhs);
                case STGrammerParser.NEQ: return new Result(true, strLhs + "<>" + strRhs);
                default: return DefaultResult;
            }
        }

        /* function */
        public override Result VisitExpr_funccall([NotNull] STGrammerParser.Expr_funccallContext context)
        {
            string strFunc = context.funcname.Text + "(";

            foreach (var e in context._args)
            {
                string str = Visit(e).Info as string;
                strFunc += str;
                strFunc += ",";
            }
            if (context._args.Count != 0)
            {
                strFunc = strFunc.Remove(strFunc.Length - 1);
            }

            foreach (var e in context._args2)
            {
                strFunc += ",";
                string str = Visit(e).Info as string;
                strFunc += str;
            }

            strFunc += ")";

            return new Result(true, strFunc);

        }

        public override Result VisitFunc_named_arg([NotNull] STGrammerParser.Func_named_argContext context)
        {
            string strLhs = Visit(context.lhs).Info as string;
            string strRhs = Visit(context.rhs).Info as string;

            switch (context.op.Type)
            {
                case STGrammerParser.ASSIGN: return new Result(true, strLhs + ":=" + strRhs);
                case STGrammerParser.OUTREF: return new Result(true, strLhs + "=>" + strRhs);
                default: return DefaultResult;
            }
        }

        public override Result VisitFunc_operation([NotNull] STGrammerParser.Func_operationContext context)
        {
            string strLhs = Visit(context.lhs).Info as string;
            string strRhs = Visit(context.rhs).Info as string;

            switch (context.op.Type)
            {
                case STGrammerParser.AND: return new Result(true, strLhs + " AND " + strRhs);
                case STGrammerParser.AND2: return new Result(true, strLhs + " AND " + strRhs);
                case STGrammerParser.OR: return new Result(true, strLhs + " OR " + strRhs);
                case STGrammerParser.XOR: return new Result(true, strLhs + " XOR " + strRhs);
                case STGrammerParser.GT: return new Result(true, strLhs + ">" + strRhs);
                case STGrammerParser.GE: return new Result(true, strLhs + ">=" + strRhs);
                case STGrammerParser.LT: return new Result(true, strLhs + "<" + strRhs);
                case STGrammerParser.LE: return new Result(true, strLhs + "<=" + strRhs);
                case STGrammerParser.EQ: return new Result(true, strLhs + "=" + strRhs);
                case STGrammerParser.NEQ: return new Result(true, strLhs + "<>" + strRhs);
                default: return DefaultResult;
            }
        }

        public override Result VisitFunc_variable([NotNull] STGrammerParser.Func_variableContext context)
        {
            return new Result(true, context.GetText());
        }

        public override Result VisitExpr_variable([NotNull] STGrammerParser.Expr_variableContext context)
        {
            return new Result(true, context.GetText());
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

        public override Result VisitType_int([NotNull] STGrammerParser.Type_intContext context)
        {
            if (context.normal_value() != null)
            {
                return new Result(true, "TOS(#" + context.normal_value().GetText() + ")");
            }
            if (context.disp_define() != null)
            {
                string str = Visit(context.disp_define()).Info as string;
                return new Result(true, "TOS(" + str + ")");
            }
            return DefaultResult;
        }

        public override Result VisitType_uint([NotNull] STGrammerParser.Type_uintContext context)
        {
            if (context.normal_value() != null)
            {
                return new Result(true, "TOU(#" + context.normal_value().GetText() + ")");
            }
            if (context.disp_define() != null)
            {
                string str = Visit(context.disp_define()).Info as string;
                return new Result(true, "TOU(" + str + ")");
            }
            return DefaultResult;
        }

        public override Result VisitType_lreal([NotNull] STGrammerParser.Type_lrealContext context)
        {
            return new Result(true, "TODF(#" + context.NUM_REAL().ToString() + ")");
        }

        public override Result VisitType_string([NotNull] STGrammerParser.Type_stringContext context)
        {
            if (context.literal() != null)
            {
                string str = Visit(context.literal()).Info as string;
                return new Result(true, "\"" + str + "\"");
            }
            if (context.variable() != null)
            {
                return new Result(true, "\"" + context.variable().GetText() + "\"");
            }
            return DefaultResult;
        }

        public override Result VisitDisp_define([NotNull] STGrammerParser.Disp_defineContext context)
        {
            string strNum = context.GetText();
            int pos = strNum.IndexOf("#");
            string strValue = strNum.Substring(pos + 1, strNum.Length - pos - 1);

            switch (context.Start.Type)
            {
                case STGrammerParser.DISP_BIN:
                    return new Result(true, "$" + Convert.ToString(Convert.ToInt32(strValue.Replace("_", ""), 2), 16));
                case STGrammerParser.DISP_OCT:
                    return new Result(true, "#" + Convert.ToString(Convert.ToInt32(strValue.Replace("_", ""), 8), 10));
                case STGrammerParser.DISP_HEX: return new Result(true, "$" + strValue);
                default: return DefaultResult;
            }
        }


        public override Result VisitExpr_normal_value([NotNull] STGrammerParser.Expr_normal_valueContext context)
        {
            switch (context.Start.Type)
            {
                case STGrammerParser.NUM_UINT: return new Result(true, "#" + int.Parse(context.Start.Text).ToString());
                case STGrammerParser.NUM_REAL: return new Result(true, "#" + float.Parse(context.Start.Text).ToString(".0"));
                default: return DefaultResult;
            }
        }

        public override Result VisitExpr_reserveword([NotNull] STGrammerParser.Expr_reservewordContext context)
        {
            switch (context.Start.Type)
            {
                case STGrammerParser.EXIT: return new Result(true, "BREAK");
                default: return DefaultResult;
            }
        }

        /* linecomment */
        public override Result VisitSt_linecomment([NotNull] STGrammerParser.St_linecommentContext context)
        {
            // 適当実装
            return new Result(true, context.GetText().Replace("//", "'"));
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
