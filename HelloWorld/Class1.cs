using System;
using log4net;
using NServiceBus;
using SecurityServiceAdapter;

namespace HelloWorld 
{
    public class Class1 : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Run()
        {
            LogManager.GetLogger("Class1").Info("Hello world!");
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            NServiceBus.Configure.With()
                .CustomConfigurationSource(new ConfigSource())
                .DefaultBuilder()
                .XmlSerializer("http://acme.com")
                .RijndaelEncryptionService();
        }
    }
}
