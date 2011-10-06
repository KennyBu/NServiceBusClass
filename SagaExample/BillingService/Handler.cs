using System;
using Billing.Messages;
using NServiceBus;
using SalesService.Messages;

namespace PublisherEndpoint
{
    public class Handler : IHandleMessages<OrderAccepted>
    {
        public IBus Bus { get; set; }

        public void Handle(OrderAccepted message)
        {
            Console.WriteLine("Received OrderAccepted {0}",message.OrderId);
            Bus.Publish(new OrderBilled{OrderId = message.OrderId});
            Console.WriteLine("Send OrderBilled {0}", message.OrderId);
        }
    }
}
