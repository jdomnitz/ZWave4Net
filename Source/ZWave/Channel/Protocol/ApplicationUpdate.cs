using System;

namespace ZWave.Channel.Protocol
{
    class ApplicationUpdate : Message
    {
        public readonly ApplicationUpdateType UpdateState;
        public readonly byte NodeID;
        public readonly byte[] Payload;

        public ApplicationUpdate(byte[] payload)
            : base(FrameHeader.SOF, MessageType.Request, Channel.Function.ApplicationUpdate)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));
            if (payload.Length < 2)
                throw new ReponseFormatException($"The response was not in the expected format. NodeEvent, payload: {BitConverter.ToString(payload)}");

            UpdateState = (ApplicationUpdateType)payload[0];
            NodeID = payload[1];
            Payload = payload;
        }
    }
}
