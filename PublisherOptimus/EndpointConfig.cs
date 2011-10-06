using System;
using log4net;
using Messages2;
using NServiceBus;

namespace PublisherEndpoint
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantToRunAtStartup
    {
        public IBus Bus { get; set; }
        
        public void Run()
        {
            while (true)
            {
                Console.ReadLine();
                LogManager.GetLogger("MessageSender").Info("Start");
                Bus.Publish(new DecepticonsAlertMessage {Information = "They're attacking!"});
            }
        }

        public void Stop()
        {
        }
    }
}
