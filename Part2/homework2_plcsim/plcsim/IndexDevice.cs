using System;
namespace plcsim
{
    public class IndexDevice : IOperand
    {
        public IndexDevice(IOperand baseOpe, IOperand indexOpe) => (Base, Index) = (baseOpe, indexOpe);

        public IOperand Base { get; }
        public IOperand Index { get; }

        public bool IsDevice() { return true; }

        public bool ToDeviceAddress(Plc plc, out Device device)
        {
            var BaseOpe = Base as Device;
            var IndexOpe = Index as Device;
            device = BaseOpe.GetIncrementDevice(plc.WordDevices[IndexOpe.ToString()]);
            
            return true;
        }

    }


}