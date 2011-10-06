using log4net;
using Messages1;
using Messages2;
using NServiceBus;

namespace PublisherEndpoint
{
    public class Handler : IHandleMessages<AutobotMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(AutobotMessage message)
        {
            Bus.Publish(new DecepticonsAlertMessage {Information = "Deceptions are coming!"});
            LogManager.GetLogger("MessageSender").Info("Sent Message");
        }
    }
}
