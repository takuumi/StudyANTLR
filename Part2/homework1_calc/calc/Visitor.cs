using System;
using System.Diagnostics;
using Antlr4.Runtime.Misc;

namespace calc
{
    class Visitor : calcBaseVisitor<Visitor.Result>
    {        
        protected override Result DefaultResult => new Result(false, ResultType.None, 0);

        public override Result VisitInput([NotNull] calcParser.InputContext context)
        {
            return Visit(context.expr());
        }

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
                            if ((ltype == ResultType.IntNumber) && (rtype == ResultType.IntNumber))
                            {
                                return new Result(true, ResultType.IntNumber, GetValInt(ltype, lValue) + GetValInt(rtype, rValue));
                            } else
                            {
                                return new Result(true, ResultType.RealNumber, GetValFloat(ltype, lValue) + GetValFloat(rtype, rValue));
                            }
                        case calcParser.MINUS:
                            if ((ltype == ResultType.IntNumber) && (rtype == ResultType.IntNumber))
                            {
                                return new Result(true, ResultType.IntNumber, GetValInt(ltype, lValue) - GetValInt(rtype, rValue));
                            }
                            else
                            {
                                return new Result(true, ResultType.RealNumber, GetValFloat(ltype, lValue) - GetValFloat(rtype, rValue));
                            }
                        default: return DefaultResult;
                    }
                }
            }
            catch (OverflowException)
            {
                return new Result(false, ResultType.None, (int)ErrString.ErrID.OverFlow);
            }
        }

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
                            if ((ltype == ResultType.IntNumber) && (rtype == ResultType.IntNumber))
                            {
                                return new Result(true, ResultType.IntNumber, GetValInt(ltype, lValue) * GetValInt(rtype, rValue));
                            } else
                            {
                                return new Result(true, ResultType.RealNumber, GetValFloat(ltype, lValue) * GetValFloat(rtype , rValue));
                            }
                        case calcParser.SLASH:

                            if ((int)rValue == 0)
                            {
                                return new Result(false, ResultType.None, (int)ErrString.ErrID.ZeroDiv);
                            }
                            else
                            {
                                if ((ltype == ResultType.IntNumber) && (rtype == ResultType.IntNumber))
                                {
                                    if (((int)lValue % (int)rValue) == 0)
                                    {
                                        return new Result(true, ResultType.IntNumber, GetValInt(ltype, lValue) / GetValInt(rtype, rValue));
                                    } else
                                    {
                                        return new Result(true, ResultType.RealNumber, GetValFloat(ltype, lValue) / GetValFloat(rtype, rValue));                                    }
                                }
                                else
                                {
                                    return new Result(true, ResultType.RealNumber, GetValFloat(ltype, lValue) / GetValFloat(rtype, rValue));
                                }
                            }
                        default: return DefaultResult;
                    }
                }
            }
            catch (OverflowException)
            {
                return new Result(false, ResultType.None, (int)ErrString.ErrID.OverFlow);
            }
        }

        public override Result VisitExpr_funccall([NotNull] calcParser.Expr_funccallContext context)
        {
            var (argSuc, argType, argValue) = Visit(context._args[0]);
            if (!argSuc) return DefaultResult;
            
            if (context.funcname.Text.ToUpper() == "SIN")
            {
                return new Result(true, ResultType.RealNumber, (float)Math.Sin(GetValFloat(argType, argValue) * (Math.PI / 180)));
            }
            else
            {
                Debug.Assert(false);
                return DefaultResult;
            }
        }

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
                            if (type==ResultType.IntNumber)
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
                return new Result(false, ResultType.None, (int)ErrString.ErrID.OverFlow);
            }

            //                            return base.VisitExpr_unary(context);
        }


        public override Result VisitNum([NotNull] calcParser.NumContext context)
        {
            switch (context.Start.Type)
            {
                case calcParser.UINT: return new Result(true, ResultType.IntNumber,int.Parse(context.Start.Text));
                case calcParser.REAL: return new Result(true, ResultType.RealNumber, float.Parse(context.Start.Text));
                default: return DefaultResult;
            }
        }


        public class Result
        {
            public Result(bool isSuccess, ResultType type, object value)
            {
                IsSuccess = isSuccess;
                Type = type;
                Value = value;
            }
            public void Deconstruct(out bool isSuccess, out ResultType type, out object value)
            {
                isSuccess = IsSuccess;
                type = Type;
                value = Value;
            }
            public bool IsSuccess { get; }
            public ResultType Type { get; }
            public object Value { get; }


       }

        public enum ResultType
        {
            None,
            IntNumber,
            RealNumber
        }

        public static int GetValInt(ResultType type, object val)
        {
            if (type == ResultType.IntNumber)
            {
                return (int)val;
            }
            else if(type == ResultType.RealNumber)
            {
                return (int)(float)val;
            } else
            {
                Debug.Assert(false);
                return 0;
            }
        }

        public static float GetValFloat(ResultType type, object val)
        {
            if (type == ResultType.IntNumber)
            {
                return (float)(int)val;
            }
            else if (type == ResultType.RealNumber)
            {
                return (float)val;
            }
            else
            {
                Debug.Assert(false);
                return 0;
            }
        }

    }

}
