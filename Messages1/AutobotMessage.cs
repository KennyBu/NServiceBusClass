using NServiceBus;

namespace Messages1
{
    public class AutobotMessage : IMessage
    {
        public string Information { get; set; }
    }
}