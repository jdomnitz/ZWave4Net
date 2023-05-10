using System;
using ZWave.Channel.Protocol;

namespace ZWave.Channel
{
    public class NodeUpdateEventArgs : EventArgs
    {
        public readonly byte NodeID;
        public readonly ApplicationUpdateType UpdateState;
        public NodeInformation NodeInfo;

        public NodeUpdateEventArgs(byte nodeID, ApplicationUpdateType state)
        {
            if ((NodeID = nodeID) == 0)
                throw new ArgumentOutOfRangeException(nameof(NodeID), nodeID, "NodeID can not be 0");
            this.UpdateState = state;
        }
    }
}
