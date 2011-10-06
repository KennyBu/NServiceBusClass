using System;
using NServiceBus.Saga;

namespace ClientEndpoint
{
    public class ShippingSagaData : IContainSagaData
    {
        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }

        public virtual Guid OrderId { get; set; }
        public virtual bool IsOrderAccepted { get; set; }
        public virtual bool IsOrderBilled { get; set; }

    }
}