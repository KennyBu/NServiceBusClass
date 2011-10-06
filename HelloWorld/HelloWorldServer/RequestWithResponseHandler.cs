using System;
using System.Threading;
using Messages;
using NServiceBus;

namespace HelloWorldServer
{
    public class RequestWithResponseHandler : IHandleMessages<RequestWithResponse>
    {
        public IBus Bus { get; set; }

        public void Handle(RequestWithResponse message)
        {
           Thread.Sleep(new TimeSpan(0,0,5));
            Bus.Return(message.SaySomething.Value.Length);
        }
    }
}