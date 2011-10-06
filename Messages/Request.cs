using NServiceBus;

namespace Messages
{
    [TimeToBeReceived("00:01:00")]
    public class Request : IMessage
    {
        public WireEncryptedString SaySomething { get; set; }
    }
}
