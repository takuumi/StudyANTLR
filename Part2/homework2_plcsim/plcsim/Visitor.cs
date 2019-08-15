using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr4.Runtime.Misc;
using static plcsim.InstTable;

namespace plcsim
{
    class Visitor : plcsimBaseVisitor<Visitor.Result>
    {
        private readonly Plc _plc;
        public Visitor(Plc plc)
        {
            _plc = plc;
        }

        protected override Result DefaultResult => new Result(false, 0);

        public override Result VisitInput([NotNull] plcsimParser.InputContext context)
        {
            foreach (var e in context.oneline()) {
                var ret = Visit(e);
                if(ret.IsSuccess == false)
                {
                    return new Result(false, 0);
                }
            }

            return new Result(true, 1);
        }

        public override Result VisitPlcsim_memonic([NotNull] plcsimParser.Plcsim_memonicContext context)
        {
            return base.VisitPlcsim_memonic(context);
        }

        public override Result VisitPlcsim_main([NotNull] plcsimParser.Plcsim_mainContext context)
        {
            //命令語
            var ret = Visit(context.command());
            var inst = ret.Info as Instruction;

            //オペランド
            var operands = new List<string>();
           
            foreach (var item in context.operand())
            {
                var retOpe = Visit(item);
                if (!retOpe.IsSuccess) return retOpe;
                operands.Add(retOpe.Info as string);
            }

            // 命令語実行
            ExecuteInst(inst, operands);
            //input系なら、plcに実行条件をセット。
            //LDの場合、どういう動作をして、実行条件がONか、どうか。を調べる

            //output系なら、plcの実行条件がONの場合、命令語を実行plcの値を変更。


            return new Result(true, 1);

        }

        private void ExecuteInst(Instruction inst, List<string> operands)
        {
            switch (inst.Name)
            {
                case "LD":
                    {
                        if(_plc.BitDevices[operands[0]])
                        {
                            _plc.ExecuteCondition = true;
                        }
                        break;
                    }
                case "MOV":
                    {
                        if(_plc.ExecuteCondition)
                        {


                            _plc.WordDevices[operands[1]] = _plc.WordDevices[operands[0]];
                        }
                        break;
                    }
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        public override Result VisitCommand([NotNull] plcsimParser.CommandContext context)
        {
            // TODO
            return new Result(true, new Instruction { Name = context.Start.Text, Attribute = InstTable.Table[context.Start.Text] } );
        }

        public override Result VisitOperand([NotNull] plcsimParser.OperandContext context)
        {
            // TODO
            return new Result(true, context.Start.Text);
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
