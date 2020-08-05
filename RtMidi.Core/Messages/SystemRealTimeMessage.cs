using RtMidi.Core.Devices;
using Serilog;

namespace RtMidi.Core.Messages
{
    /// <summary>
    /// This message contains System Real-Time messages sent from the device to the host.
    /// </summary>
    public readonly struct SystemRealTimeMessage
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<SystemRealTimeMessage>();

        public SystemRealTimeMessage(byte data)
        {
            Data = data;
        }

        /// <summary>
        /// SysEx Data Array
        /// </summary>
        public byte Data { get; }

        internal byte[] Encode()
        {
            return new byte[] { Data };
        }

        internal static bool TryDecode(byte message, out SystemRealTimeMessage msg)
        {
            msg = new SystemRealTimeMessage
            (
                message
            );
            return true;
        }

        public override string ToString()
        {
            return $"{nameof(Data)}: {Data}";
        }
    }
}
