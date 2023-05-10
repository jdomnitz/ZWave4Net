using System.Collections.Generic;

namespace ZWave
{
    public class NodeProtocolInfo
    {
        public byte Capability { get; private set; }
        public byte Reserved { get; private set; }
        public BasicType BasicType { get; private set; }
        public GenericType GenericType { get; private set; }
        public SpecificType SpecificType { get; private set; }
        public Security Security { get; private set; }

        public NodeProtocolInfo(byte[] data)
        {
            Capability = data[0];
            Security = (Security)data[1];
            Reserved = data[2];
            BasicType = (BasicType)data[3];
            GenericType = (GenericType)data[4];
            SpecificType = SpecificTypeMapping.Get((GenericType)data[4], data[5]);
        }

        public bool Routing
        {
            get { return (Capability & 0x40) != 0; }
        }

        public bool IsListening
        {
            get { return (Capability & 0x80) != 0; }
        }

        public decimal Version
        {
            get
            {
                if ((Capability & 0x07) == 0x1)
                    return 2.0M;
                return (Capability & 0x07) + 3.0M;
            }
        }

        public int[] BaudRates
        {
            get {
                List<int> rates = new List<int>();
                if ((Capability & 0x8) == 0x8)
                    rates.Add(9600);
                if ((Capability & 0x10) == 0x10)
                    rates.Add(40000);
                if ((Reserved & 0x1) == 0x1)
                    rates.Add(100000);
                return rates.ToArray();
            }
        }

        public override string ToString()
        {
            return $"GenericType = {GenericType}, BasicType = {BasicType}, Listening = {IsListening}, Version = {Version}, Security = [{Security}], Routing = {Routing}, BaudRates = {string.Join(",", BaudRates)}";
        }
    }
}
