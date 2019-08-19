using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace plcsim
{
    static class InstructionExecuter
    {

        internal static ErrString.ErrID Execute(Plc _plc, InstTable.Instruction inst, List<IOperand> operands)
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


                        if (!_plc.ExecuteCondition)
                        {
                            // 実行条件OFFなので何もせず
                            break;
                        }

                        if (!operands.ElementAt(1).IsDevice())
                        {
                            // 第２引数はデバイスじゃないとNG
                            return ErrString.ErrID.UnSupportArgType;
                        }
                        var ope1 = operands.ElementAt(1) as Device;

                        if (operands.ElementAt(0).IsDevice())
                        {
                            var ope0 = operands.ElementAt(0) as Device;

                            // オペランドの存在確認
                            if (!_plc.WordDevices.ContainsKey(ope0.ToString()))
                            {
                                return ErrString.ErrID.NoPLCDevice;
                            }

                            if (!_plc.WordDevices.ContainsKey(ope1.ToString()))
                            {
                                return ErrString.ErrID.NoPLCDevice;
                            }

                            // MOV動作
                            if (inst.Suffix == ".U" || inst.Suffix == "")
                            {
                                _plc.WordDevices[ope1.ToString()] = _plc.WordDevices[ope0.ToString()];
                            }
                            else if (inst.Suffix == ".D")
                            {
                                // +1のデバイスのインクリメント
                                var ope0Inc = ope0.GetIncrementDevice(1);
                                var ope1Inc = ope1.GetIncrementDevice(1);

                                if (!_plc.WordDevices.ContainsKey(ope0Inc.ToString()))
                                {
                                    return ErrString.ErrID.NoPLCDevice;
                                }

                                if (!_plc.WordDevices.ContainsKey(ope1Inc.ToString()))
                                {
                                    return ErrString.ErrID.NoPLCDevice;
                                }

                                _plc.WordDevices[ope1.ToString()] = _plc.WordDevices[ope0.ToString()];
                                _plc.WordDevices[ope1Inc.ToString()] = _plc.WordDevices[ope0Inc.ToString()];
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



    }
}
