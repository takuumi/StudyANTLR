using System;
using Antlr4.Runtime.Misc;

namespace calc
{
    class Visitor : calcBaseVisitor<Visitor.Result>
    {        
        protected override Result DefaultResult => new Result(false, 0);
        //public override Result VisitInput([NotNull] calcParser.InputContext context) => Visit(context);

        public override Result VisitCalc_add([NotNull] calcParser.Calc_addContext context)
        {
            return new Result(true, int.Parse(context.lhs.Text) + int.Parse(context.rhs.Text));
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
