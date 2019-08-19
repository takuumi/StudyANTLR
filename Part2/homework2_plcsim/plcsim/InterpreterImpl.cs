using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Antlr4.Runtime.Misc;
using static plcsim.InstTable;

namespace plcsim
{
    class InterpreterImpl : plcsimBaseVisitor<InterpreterImpl.Result>
    {
        private readonly Plc _plc;
        public InterpreterImpl(Plc plc)
        {
            _plc = plc;
        }


        // TODO もう少しうまくかけないのか？
        public override Result VisitInput([NotNull] plcsimParser.InputContext context)
        {
            foreach (var e in context.oneline())
            {
                var ret = Visit(e);
                if (!ret.IsSuccess) return ret;
            }
            return new Result(true, 0);    
        }

        public override Result VisitPlcsim_memonic([NotNull] plcsimParser.Plcsim_memonicContext context) => Visit(context.mnemonic());
        public override Result VisitPlcsim_linecomment([NotNull] plcsimParser.Plcsim_linecommentContext context) => Visit(context.linecomment());
        public override Result VisitPlcsim_main([NotNull] plcsimParser.Plcsim_mainContext context)
        {
            //命令語の解析
            var retInst = InstructionAnalyzer.TryAnalyze(context.instruction());
            if (!retInst.IsSuccess) return retInst;
            var inst = retInst.Info as Instruction;

            //オペランドの解析
            var operands = new List<IOperand>();
            var retOpe = OperandAnalyzer.TryAnalyze(context.operand(), ref operands);
            if (!retOpe.IsSuccess) return retOpe;

            // 命令語実行
            var errid = InstructionExecuter.Execute(_plc, inst, operands);
            if (errid != ErrString.ErrID.None)
            {
                return new Result(false, errid);
            }

            return new Result(true, 0);
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
