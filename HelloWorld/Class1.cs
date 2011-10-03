using System;
using log4net;
using NServiceBus;

namespace HelloWorld 
{
    public class Class1 : IConfigureThisEndpoint, IWantToRunAtStartup
    {
        public void Run()
        {
            LogManager.GetLogger("Class1").Info("Hello world!");
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
