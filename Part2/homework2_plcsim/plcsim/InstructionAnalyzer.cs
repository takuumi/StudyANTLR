using System.Collections.Generic;
using static plcsim.InstTable;
using static plcsim.InterpreterImpl;

namespace plcsim
{
    //命令語のアナライザ。
    static class InstructionAnalyzer
    {
        public static Result TryAnalyze(plcsimParser.InstructionContext context)
        {
            // 命令語
            var inst = context.Start.Text;
            if (!InstTable.Table.ContainsKey(inst))
            {
                return new Result(false, ErrString.ErrID.UnSupportInst);
            }

            // サッフィックス
            string strSuf = "";
            if (context.suffix != null)
            {
                strSuf = context.suffix.Text;
            }

            return new Result(true, new Instruction { Name = inst, Suffix = strSuf, Attribute = InstTable.Table[inst] });
        }
    }

    static class InstTable
    {
        public enum Direction
        {
            In,
            Out
        }

        public class Instruction
        {
            public string Name { get; set; }
            public string Suffix { get; set; }
            public InstAttribute Attribute { get; set; }
        }

        public class InstAttribute
        {
            public Direction Direction { get; set; }
            public int ArgNum { get; set; }
        }

        //TODO
        public static IDictionary<string, InstAttribute> Table => _table;
        private static Dictionary<string, InstAttribute> _table = new Dictionary<string, InstAttribute>
        {
            {"LD", new InstAttribute { Direction = Direction.In, ArgNum = 1} },
            {"MOV", new InstAttribute { Direction = Direction.Out, ArgNum = 2} },
        };
    }
}


