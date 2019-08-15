using System.Collections.Generic;

namespace plcsim
{
    public class Plc
    {
        public Plc()
        {
     
        }

        public Dictionary<string, bool> BitDevices { get; } = new Dictionary<string, bool>();
        public Dictionary<string, ushort> WordDevices { get; } = new Dictionary<string, ushort>();
        public bool ExecuteCondition { get; internal set; } = false;
    }
}