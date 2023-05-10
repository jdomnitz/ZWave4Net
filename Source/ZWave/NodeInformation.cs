using ZWave.Channel;

namespace ZWave
{
    public class NodeInformation : NodeProtocolInfo
    {
        public CommandClass[] CommandClasses { get; }
        public NodeInformation(byte[] data) : base(data)
        {
            CommandClasses = new CommandClass[data.Length-6];
            for (int i = 6; i < data.Length; i++)
                CommandClasses[i-6] = (CommandClass)data[i];
        }

        public override string ToString()
        {
            return base.ToString() + $", CommandClasses = {string.Join(",", CommandClasses)}";
        }
    }
}
