using System.Collections.Generic;
using System.Diagnostics;

namespace calc
{
    static public class ErrString
    {
        public enum ErrID
        {
            OverFlow = 0,
            ZeroDiv,
            UnSupportCalcRule,
            CantMinusString
        }

        static Dictionary<ErrID, string> _dict = new Dictionary<ErrID, string>
        {
            {ErrID.OverFlow, "Err.OverFlow"},
            {ErrID.ZeroDiv, "Err.ZeroDiv"},
            {ErrID.UnSupportCalcRule, "Err.UnSupportCalcRule" },
            {ErrID.CantMinusString, "Err.CantMinusString" }
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
                Debug.Assert(false);
                return null;
            }
        }
    }
}
