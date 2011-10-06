using System;
using Billing.Messages;
using NServiceBus.Saga;
using SalesService.Messages;

namespace ClientEndpoint
{
    public class ShippingSaga : Saga<ShippingSagaData>,
         IAmStartedByMessages<OrderAccepted>,
         IAmStartedByMessages<OrderBilled>

    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<OrderAccepted>(saga => saga.OrderId, message => message.OrderId);
            ConfigureMapping<OrderBilled>(saga => saga.OrderId, message => message.OrderId);
        }
        
        public void Handle(OrderAccepted message)
        {
            Data.OrderId = message.OrderId;
            Data.IsOrderAccepted = true;

            Console.WriteLine("Order Accepted: {0}", message.OrderId);

            if (Data.IsOrderBilled)
            {
                Console.WriteLine("Order Shipped: {0}",message.OrderId);
                MarkAsComplete();
            }
        }

        public void Handle(OrderBilled message)
        {
            Data.OrderId = message.OrderId;
            Data.IsOrderBilled = true;

            Console.WriteLine("Order Billed: {0}", message.OrderId);

            if (Data.IsOrderAccepted)
            {
                Console.WriteLine("Order Shipped: {0}", message.OrderId);
                MarkAsComplete();
            }
        }
    }
}