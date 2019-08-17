using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                if (!ret.IsSuccess) return ret;
            }
            return new Result(true, 0);
        }

        public override Result VisitPlcsim_memonic([NotNull] plcsimParser.Plcsim_memonicContext context)
        {
            return base.VisitPlcsim_memonic(context);
        }

        public override Result VisitPlcsim_main([NotNull] plcsimParser.Plcsim_mainContext context)
        {
            //命令語
            var retInst = Visit(context.command());
            var inst = retInst.Info as Instruction;

            //オペランド
            var operands = new List<IOperand>();
            foreach (var item in context.operand())
            {
                var retOpe = Visit(item);
                if (!retOpe.IsSuccess) return retOpe;
                operands.Add(retOpe.Info as IOperand);
            }

            // 命令語実行
            var errid = ExecuteInst(inst, operands);
            if (errid != ErrString.ErrID.None)
            {
                return new Result(false, errid);
            }

            return new Result(true, 0);
        }

        private ErrString.ErrID ExecuteInst(Instruction inst, List<IOperand> operands)
        {
            switch (inst.Name)
            {
                case "LD":
                    {
                        var ope = operands.ElementAt(0) as Device;

                        bool bResult;
                        if (_plc.BitDevices.TryGetValue(ope.ToString(), out bResult))
                        {
                            // TODO 複数条件あったら、全条件分を貯めておいて処理か。
                            _plc.ExecuteCondition = bResult;
                        }
                        else
                        {
                            return ErrString.ErrID.NoPLCDevice;
                        }
                        break;
                    }
                case "MOV":
                    {
                        var ope0 = operands.ElementAt(0) as Device;
                        var ope1 = operands.ElementAt(1) as Device;

                        if (_plc.ExecuteCondition)
                        {
                            if (inst.Suffix == ".U" || inst.Suffix == "")
                            {

                                if (!_plc.WordDevices.ContainsKey(ope0.ToString()))
                                {
                                    return ErrString.ErrID.NoPLCDevice;
                                }

                                if (!_plc.WordDevices.ContainsKey(ope1.ToString()))
                                {
                                    return ErrString.ErrID.NoPLCDevice;
                                }
                                // MOVの動作
                                _plc.WordDevices[ope1.ToString()] = _plc.WordDevices[ope0.ToString()];
                            }
                            else if (inst.Suffix == ".D")
                            {
                                // TODO
                                //deviceクラスに文字列作ってもらって、plcに問い合わせ。それをMOV
                                var strOpe0 = ope0.ToString();
                                var strOpe1 = ope1.ToString();

                                


                            }
                        }
                        break;
                    }
                default:
                    Debug.Assert(false);
                    break;
            }
            return ErrString.ErrID.None;
        }

        public override Result VisitCommand([NotNull] plcsimParser.CommandContext context)
        {
            // 命令語
            var inst = context.Start.Text;
            if (!InstTable.Table.ContainsKey(inst))
            {
                return new Result(false, ErrString.ErrID.UnSupportInst);
            }

            // サッフィックス
            string strSuf = "";
            if(context.suffix !=null)
            {
                strSuf = context.suffix.Text;
            }

            return new Result(true, new Instruction { Name = inst, Suffix = strSuf ,Attribute = InstTable.Table[inst] } );
        }

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
