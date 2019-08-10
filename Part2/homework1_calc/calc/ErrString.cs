using System;
using System.Collections.Generic;

namespace calc
{
    static public class ErrString
    {
        public enum ErrID
        {
            OverFlow = 0,
            ZeroDiv
        }

        static Dictionary<ErrID, string> _dict = new Dictionary<ErrID, string>
        {
            {ErrID.OverFlow, "Err.OverFlow"},
            {ErrID.ZeroDiv, "Err.ZeroDiv"}
        };

        static public string GetErrString(ErrID id)
        {
            string result;
            if (_dict.TryGetValue(id, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
