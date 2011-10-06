using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using NServiceBus.ObjectBuilder;

namespace HelloWorldQueryServer
{
     public class Class1 : IConfigureThisEndpoint, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com/")
                .MsmqTransport()
                .UnicastBus()
                .LoadMessageHandlers();
        }
    }
}