using System;
using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using static plcsim.InterpreterImpl;

namespace plcsim
{
    static class OperandAnalyzer
    {
        public static Result TryAnalyze(plcsimParser.OperandContext[] context, ref List<IOperand> operands)
        {
            foreach (var item in context)
            {
                var retOpe = new OperandAnalyzerImpl().Visit(item);
                if (!retOpe.IsSuccess) return retOpe;
                operands.Add(retOpe.Info as IOperand);
            }

            return new Result(true, 0);
        }
                    
        private class OperandAnalyzerImpl : plcsimBaseVisitor<Result>
        {
            public override Result VisitOperand([NotNull] plcsimParser.OperandContext context)
            {
                // TODO 間接とか、インデックスとか。
                var ident = context.IDENTIFIER();
                var deviceStr = ident.GetText().ToUpper();

                Device device;
                if (!Device.TryParse(deviceStr, out device))
                {
                    return new Result(false, ErrString.ErrID.UnSupportDevice);
                }
                return new Result(true, device);
            }
        }
    }
}