using System;
using NServiceBus;

namespace SalesService.Messages
{
    public class OrderAccepted : IMessage
    {
        public Guid OrderId { get; set; }
    }
}