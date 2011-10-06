using NServiceBus;

namespace Messages2
{
    public class DecepticonsAlertMessage : IMessage 
    {
        public string Information { get; set; }
    }
}