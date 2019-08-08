using System;
using Antlr4.Runtime.Misc;

namespace calc
{
    class Visitor : calcBaseVisitor<Visitor.Result>
    {        
        protected override Result DefaultResult => new Result(false, 0);

        public override Result VisitInput([NotNull] calcParser.InputContext context)
        {
            return Visit(context.expr());
        }

        public override Result VisitExpr_additive([NotNull] calcParser.Expr_additiveContext context)
        {
            var (lSuc, lValue) = Visit(context.lhs);
            var (rSuc, rValue) = Visit(context.rhs);
            if (!(lSuc && rSuc)) return DefaultResult;

            switch (context.op.Type)
            {
                case calcParser.PLUS: return new Result(true, lValue + rValue);
                case calcParser.MINUS: return new Result(true, lValue - rValue);
                default: return DefaultResult;
            }
        }

        public override Result VisitExpr_multipricative([NotNull] calcParser.Expr_multipricativeContext context)
        {
            var (lSuc, lValue) = Visit(context.lhs);
            var (rSuc, rValue) = Visit(context.rhs);
            if (!(lSuc && rSuc)) return DefaultResult;

            switch (context.op.Type)
            {
                case calcParser.ASTERISK:
                    return new Result(true, lValue * rValue);
                case calcParser.SLASH:
                    if (rValue==0)
                    {
                        return new Result(false, 0);
                    }
                    else
                    {
                        return new Result(true, lValue / rValue);
                    }
                    default: return DefaultResult;
            }

        }




        public override Result VisitNum([NotNull] calcParser.NumContext context)
        {
            switch (context.Start.Type)
            {
                case calcParser.UINT: return new Result(true, int.Parse(context.Start.Text));
                default: return DefaultResult;
            }
        }


        public class Result
        {
            public Result(bool isSuccess, int value) { IsSuccess = isSuccess; Value = value; }
            public void Deconstruct(out bool isSuccess, out int value)
            {
                isSuccess = IsSuccess;
                value = Value;
            }
            public bool IsSuccess { get; }
            public int Value { get; }
        }
    }

}
