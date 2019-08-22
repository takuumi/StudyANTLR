using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace plcsim
{
    static public class ErrString
    {
        public enum ErrID
        {
            None = 0,
            NoPLCDevice,
            UnSupportInst,
            UnSupportDevice,
            UnSupportArgType,
            NoDeviceAddress
        }

        static Dictionary<ErrID, string> _dict = new Dictionary<ErrID, string>
        {
            {ErrID.None, "No Err"},
            {ErrID.NoPLCDevice, "No PLC Device" },
            {ErrID.UnSupportInst, "UnSupportInst" },
            {ErrID.UnSupportDevice, "UnSupportDevice" },
            {ErrID.UnSupportArgType, "UnsupportArgType" },
            {ErrID.NoDeviceAddress, "NoDeviceAddress" }

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
