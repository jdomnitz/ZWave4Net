using System;
using ZWave.Channel.Protocol;

namespace ZWave.Channel
{
    public class ApplicationUpdateEventArgs : EventArgs
    {
        public readonly byte NodeID;
        public readonly ApplicationUpdateType UpdateState;
        public readonly byte[] Payload;

        public ApplicationUpdateEventArgs(byte nodeID, ApplicationUpdateType state, byte[] payload)
        {
            if ((NodeID = nodeID) == 0)
                throw new ArgumentOutOfRangeException(nameof(NodeID), nodeID, "NodeID can not be 0");
            this.UpdateState = state;
            Payload = payload;
        }
    }
}
