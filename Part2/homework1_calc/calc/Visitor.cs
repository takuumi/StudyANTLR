using System;
using System.Diagnostics;
using Antlr4.Runtime.Misc;

namespace calc
{
    class Visitor : calcBaseVisitor<Visitor.Result>
    {        
        protected override Result DefaultResult => new Result(false, CalcRule.None, 0);

        public override Result VisitInput([NotNull] calcParser.InputContext context)
        {
            return Visit(context.expr());
        }

        //＋、ーの計算
        public override Result VisitExpr_additive([NotNull] calcParser.Expr_additiveContext context)
        {
            var (lSuc, ltype, lValue) = Visit(context.lhs);
            var (rSuc, rtype, rValue) = Visit(context.rhs);
            if (!(lSuc && rSuc)) return DefaultResult;
            try
            {
                checked
                {
                    switch (context.op.Type)
                    {
                        case calcParser.PLUS:
                            if ((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcInt))
                            {
                                return new Result(true, CalcRule.CalcInt, GetValInt(ltype, lValue) + GetValInt(rtype, rValue));
                            }
                            else if ((ltype == CalcRule.CalcString) && (rtype == CalcRule.CalcString))
                            {
                                return new Result(true, CalcRule.CalcString, (string)lValue + (string)rValue);
                            }
                            else if ((ltype == CalcRule.CalcReal) && (rtype == CalcRule.CalcReal))
                            {
                                return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) + GetValFloat(rtype, rValue));
                            }
                            else if (((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcReal)) ||
                                     ((ltype == CalcRule.CalcReal) && (rtype == CalcRule.CalcInt)))
                            {
                                return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) + GetValFloat(rtype, rValue));
                            }
                            else
                            {
                                return new Result(false, CalcRule.None, (int)ErrString.ErrID.UnSupportCalcRule);
                            }
                        case calcParser.MINUS:
                            if ((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcInt))
                            {
                                return new Result(true, CalcRule.CalcInt, GetValInt(ltype, lValue) - GetValInt(rtype, rValue));
                            }
                            else　if ((ltype == CalcRule.CalcString) && (rtype == CalcRule.CalcString))
                            {
                                string rStr = ((string)rValue);
                                string lStr = ((string)lValue);

                                // 元のながさチェック
                                var lLen = lStr.Length;
                                var retStr = lStr.Replace(rStr, "");

                                if (lLen == retStr.Length)
                                {
                                    // 文字列の引き算に失敗
                                    return new Result(false, CalcRule.None, (int)ErrString.ErrID.CantMinusString);
                                } else
                                {
                                    // 文字列の引き算（空白Replace）に成功
                                    return new Result(true, CalcRule.CalcString, retStr);
                                }
                            }
                            else if ((ltype == CalcRule.CalcReal) && (rtype == CalcRule.CalcReal))
                            {
                                return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) - GetValFloat(rtype, rValue));
                            }
                            else if (((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcReal)) ||
                                     ((ltype == CalcRule.CalcReal) && (rtype == CalcRule.CalcInt)))
                            {
                                return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) - GetValFloat(rtype, rValue));
                            }
                            else
                            {
                                return new Result(false, CalcRule.None, (int)ErrString.ErrID.UnSupportCalcRule);
                            }
                        default:
                            Debug.Assert(false);
                            return DefaultResult;
                    }
                }
            }
            catch (OverflowException)
            {
                return new Result(false, CalcRule.None, (int)ErrString.ErrID.OverFlow);
            }
        }

        //＊、/の計算
        public override Result VisitExpr_multipricative([NotNull] calcParser.Expr_multipricativeContext context)
        {
            var (lSuc, ltype, lValue) = Visit(context.lhs);
            var (rSuc, rtype, rValue) = Visit(context.rhs);
            if (!(lSuc && rSuc)) return DefaultResult;

            try
            {
                checked
                {
                    switch (context.op.Type)
                    {
                        case calcParser.ASTERISK:
                            if ((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcInt))
                            {
                                return new Result(true, CalcRule.CalcInt, GetValInt(ltype, lValue) * GetValInt(rtype, rValue));
                            }
                            else if ((ltype == CalcRule.CalcString) && (rtype == CalcRule.CalcString))
                            {
                                Debug.Assert(false);
                                return DefaultResult;
                            }
                            else if ((ltype == CalcRule.CalcReal) && (rtype == CalcRule.CalcReal))
                            {
                                return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) * GetValFloat(rtype, rValue));
                            }
                            else if (((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcReal)) ||
                                     ((ltype == CalcRule.CalcReal) && (rtype == CalcRule.CalcInt)))
                            {
                                return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) * GetValFloat(rtype, rValue));
                            }
                            else if (((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcString)) ||
                                     ((ltype == CalcRule.CalcString) && (rtype == CalcRule.CalcInt)))
                            {
                                var iNum = 0;
                                string str;
                                string strReturn = "";
                                if (ltype == CalcRule.CalcInt)
                                {
                                    iNum = GetValInt(ltype, lValue);
                                    str = (string)rValue;
                                }
                                else
                                {
                                    iNum = GetValInt(rtype, rValue);
                                    str = (string)lValue;
                                }
                                for (int i = 0; i < iNum; i++)
                                {
                                    strReturn += str;
                                }

                                return new Result(true, CalcRule.CalcString, strReturn);
                            }
                            else
                            {
                                Debug.Assert(false);
                                return DefaultResult;
                            }
                        case calcParser.SLASH:

                            if ((int)rValue == 0)
                            {
                                return new Result(false, CalcRule.None, (int)ErrString.ErrID.ZeroDiv);
                            }
                            else
                            {
                                if ((ltype == CalcRule.CalcInt) && (rtype == CalcRule.CalcInt))
                                {
                                    if (((int)lValue % (int)rValue) == 0)
                                    {
                                        return new Result(true, CalcRule.CalcInt, GetValInt(ltype, lValue) / GetValInt(rtype, rValue));
                                    } else
                                    {
                                        return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) / GetValFloat(rtype, rValue));                                    }
                                }
                                else
                                {
                                    return new Result(true, CalcRule.CalcReal, GetValFloat(ltype, lValue) / GetValFloat(rtype, rValue));
                                }
                            }
                        default: return DefaultResult;
                    }
                }
            }
            catch (OverflowException)
            {
                return new Result(false, CalcRule.None, (int)ErrString.ErrID.OverFlow);
            }
        }

        //独自関数の計算
        public override Result VisitExpr_funccall([NotNull] calcParser.Expr_funccallContext context)
        {
            var (argSuc, argType, argValue) = Visit(context._args[0]);
            if (!argSuc) return DefaultResult;
            
            if (context.funcname.Text.ToUpper() == "SIN")
            {
                return new Result(true, CalcRule.CalcReal, (float)Math.Sin(GetValFloat(argType, argValue) * (Math.PI / 180)));
            }
            if (context.funcname.Text.ToUpper() == "LEN"){
                string str = (string)argValue;
                return new Result(true, CalcRule.CalcInt, str.Length);
            }
            else
            {
                Debug.Assert(false);
                return DefaultResult;
            }
        }

        // (- 123)の計算 
        public override Result VisitExpr_unary([NotNull] calcParser.Expr_unaryContext context)
        {
            var (Suc, type, value) = base.VisitExpr_unary(context);
            if (!Suc) return DefaultResult; 

            try
            {
                checked
                {
                    switch (context.op.Type)
                    {
                        case calcParser.PLUS:   return new Result(true, type, value);
                        case calcParser.MINUS:
                            if (type==CalcRule.CalcInt)
                            {

                                return new Result(true, type, GetValInt(type, value) * -1);
                            }
                            else
                            {
                                return new Result(true, type, GetValFloat(type, value) * -1);
                            }
                        default: return DefaultResult;
                    }
                }
            }
            catch (OverflowException)
            {
                return new Result(false, CalcRule.None, (int)ErrString.ErrID.OverFlow);
            }
        }


        // 数値の解釈
        public override Result VisitNum([NotNull] calcParser.NumContext context)
        {
            switch (context.Start.Type)
            {
                case calcParser.UINT: return new Result(true, CalcRule.CalcInt,int.Parse(context.Start.Text));
                case calcParser.REAL: return new Result(true, CalcRule.CalcReal, float.Parse(context.Start.Text));
                default: return DefaultResult;
            }
        }

        
        // 独自定義の解釈
        public override Result VisitExpr_define([NotNull] calcParser.Expr_defineContext context)
        {
            if (context.Start.Text.ToUpper() == ("PI"))
            {
                return new Result(true, CalcRule.CalcReal, (float)Math.PI);
            } else
            {
                Debug.Assert(false);
                return DefaultResult;
            }
        }

        // 文字列の解釈
        public override Result VisitExpr_string([NotNull] calcParser.Expr_stringContext context)
        {
            return new Result(true, CalcRule.CalcString, TrimFrontAndEndDQ(context.Start.Text));
        }

        // 結果クラス
        public class Result
        {
            public Result(bool isSuccess, CalcRule type, object value)
            {
                IsSuccess = isSuccess;
                Type = type;
                Value = value;
            }

            public void Deconstruct(out bool isSuccess, out CalcRule type, out object value)
            {
                isSuccess = IsSuccess;
                type = Type;
                value = Value;
            }
            public bool IsSuccess { get; }
            public CalcRule Type { get; }
            public object Value { get; }
        }

        // 計算ルール
        public enum CalcRule
        {
            None,
            CalcInt,
            CalcReal,
            CalcString
        }

        // Int値の取得
        public static int GetValInt(CalcRule type, object val)
        {
            if (type == CalcRule.CalcInt)
            {
                return (int)val;
            }
            else if(type == CalcRule.CalcReal)
            {
                return (int)(float)val;
            } else
            {
                Debug.Assert(false);
                return 0;
            }
        }

        // real値の取得
        public static float GetValFloat(CalcRule type, object val)
        {
            if (type == CalcRule.CalcInt)
            {
                return (float)(int)val;
            }
            else if (type == CalcRule.CalcReal)
            {
                return (float)val;
            }
            else
            {
                Debug.Assert(false);
                return 0;
            }
        }

        // ""のトリム
        public static string TrimFrontAndEndDQ(string str)
        {
            str = str.Remove(0, 1);
            return str.Remove(str.Length - 1, 1);
        }
    }
}
