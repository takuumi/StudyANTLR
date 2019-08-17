using System;
using System.Collections.Generic;
using System.Linq;

namespace plcsim
{
    public class Device : IOperand
    {
        public DeviceCode Code { get; }
        public uint Address { get; private set; }

        private Device(DeviceCode code, uint address)
        {
            Code = code;
            Address = address;
        }

        public void Increment(int value)
        {
            Address = (uint)(Address + value);
        }

        public static bool TryParse(string input, out Device device)
        {
            foreach (var key in DeviceTable.Table.Keys)
            {
                if (input.StartsWith(key, StringComparison.Ordinal))
                {
                    var code = DeviceTable.Table[key];
                    uint address;
                    if (!uint.TryParse(input.Replace(key, string.Empty), out address))
                    {
                        device = new Device(DeviceCode.None, 0);
                        return false;
                    }

                    device = new Device(code, address);
                    return true;
                }
            }
            device = new Device(DeviceCode.None, 0);
            return false;
        }

        public override string ToString()
        {
            // ValueからKeyを検索。先がち仕様。
            var key = DeviceTable.Table.First(x => x.Value == Code).Key;
            return key + Address.ToString();
        }
    }

    public enum DeviceCode
    {
        None,
        R,
        DM,
    }

    public static class DeviceTable
    {
        public static IDictionary<string, DeviceCode> Table => _table;
        private static Dictionary<string, DeviceCode> _table = new Dictionary<string, DeviceCode>
        {
            {"R", DeviceCode.R},
            {"DM", DeviceCode.DM },
            {"D", DeviceCode.DM}
        };
    }
}
