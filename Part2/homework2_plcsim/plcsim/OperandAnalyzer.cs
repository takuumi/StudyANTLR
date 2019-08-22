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
            // 通常デバイス
            public override Result VisitPlcsim_ident([NotNull] plcsimParser.Plcsim_identContext context)
            {
                Device device;
                if (!TryParseDevice(context.IDENTIFIER().GetText().ToUpper(), out device))
                {
                    return new Result(false, ErrString.ErrID.UnSupportDevice);

                }
                return new Result(true, device);
            }

            // インデックスデバイス
            public override Result VisitPlcsim_indexed([NotNull] plcsimParser.Plcsim_indexedContext context)
            {
                var baseOpe = Visit(context.baseope);
                var IndexOpe = Visit(context.indexope);

                if (!baseOpe.IsSuccess) return baseOpe;
                if (!IndexOpe.IsSuccess) return IndexOpe;

                return new Result(true, new IndexDevice(baseOpe.Info as IOperand, IndexOpe.Info as IOperand));
            }


            public override Result VisitIndex([NotNull] plcsimParser.IndexContext context)
            {
                Device device;
                if (!TryParseDevice(context.IDENTIFIER().GetText().ToUpper(), out device))
                {
                    return new Result(false, ErrString.ErrID.UnSupportDevice);

                }
                return new Result(true, device);

            }

            private bool TryParseDevice(string strInput, out Device device)
            {
                if (!Device.TryParse(strInput, out device))
                {
                    return false;
                }
                return true;
            }

        }
    }
}
