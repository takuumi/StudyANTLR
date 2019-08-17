using System;
using System.Collections.Generic;

namespace plcsim
{
    public static class InstTable
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
            public Direction Direction{ get; set; }
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
