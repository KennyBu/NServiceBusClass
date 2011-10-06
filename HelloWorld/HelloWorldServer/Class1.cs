using NServiceBus;
using NServiceBus.ObjectBuilder;
using SecurityServiceAdapter;

namespace HelloWorldServer
{
    public class Class1 : IConfigureThisEndpoint, AsA_Server , IWantCustomInitialization,
        ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            NServiceBus.Configure.With()
                .CustomConfigurationSource(new ConfigSource())
                .DefaultBuilder()
                .XmlSerializer("http://acme.com/")
                .RunCustomAction(() => 
                    Configure.Instance.Configurer.ConfigureComponent<SaySomething>(
                    ComponentCallModelEnum.Singleton)
                )
                .RijndaelEncryptionService();
        }

        public void SpecifyOrder(Order order)
        {
            order.Specify<First<Auth>>();
        }
    }
}
