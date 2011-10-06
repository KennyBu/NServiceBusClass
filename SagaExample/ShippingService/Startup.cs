using System;
using Billing.Messages;
using NServiceBus;
using SalesService.Messages;

namespace ClientEndpoint
{
    public class Startup : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            Bus.Subscribe<OrderAccepted>();
            Bus.Subscribe<OrderBilled>();
        }

        public void Stop()
        {
            Bus.Unsubscribe<OrderAccepted>();
            Bus.Unsubscribe<OrderBilled>();
        }
    }
}