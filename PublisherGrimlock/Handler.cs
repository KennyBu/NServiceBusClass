using log4net;
using Messages1;
using Messages2;
using NServiceBus;

namespace PublisherEndpoint
{
    public class Handler : IHandleMessages<DecepticonsAlertMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(DecepticonsAlertMessage message)
        {
            
            Bus.Publish(new AutobotMessage{Information = "Autobots Roll Out!"});
            LogManager.GetLogger("MessageSender").Info("Sent Message");
        }
    }
}
