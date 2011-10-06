using System;
using NServiceBus;
using SalesService.Messages;

namespace PublisherEndpoint
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher
    {
    }
}

public class Runner :IWantToRunAtStartup
{
    public IBus Bus { get; set; }
    
    public void Run()
    {
        Console.WriteLine("Please Hit Enter");
        while(Console.ReadLine() != null)
        {
            var id = Guid.NewGuid();
            Bus.Publish(new OrderAccepted { OrderId = id });
            Console.WriteLine("Sent Order {0}", id);
            Console.WriteLine("Please Hit Enter");
        }
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }
}
