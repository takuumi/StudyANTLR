using System;
namespace plcsim
{
    public interface IOperand
    {
        bool ToDeviceAddress(Plc plc, out Device device);
        bool IsDevice();
    }
}
