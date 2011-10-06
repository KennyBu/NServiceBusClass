using System;
using log4net;
using Messages;
using NServiceBus;

namespace HelloWorld
{
    public class MessageSender : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            Bus.OutgoingHeaders["user"] = "udi";
            var message = new Request {SaySomething = "Say Something"};
            Bus.Send(message);
            LogManager.GetLogger("MessageSender").Info("Sent Message");
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}