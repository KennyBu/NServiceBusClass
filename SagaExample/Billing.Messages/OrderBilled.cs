using System;
using NServiceBus;

namespace Billing.Messages
{
    public class OrderBilled : IMessage
    {
        public Guid OrderId { get; set; }
    }
}