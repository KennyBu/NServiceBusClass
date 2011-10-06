using System.Configuration;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using SecurityServiceAdapter.ServiceReference1;

namespace SecurityServiceAdapter
{
    public class ConfigSource : IConfigurationSource
    {
        public T GetConfiguration<T>() where T : class
        {
            if (typeof(T) == typeof(RijndaelEncryptionServiceConfig))
            {
                var svc = new SecurityServiceClient();
                var key = svc.GetKey();
                svc.Close();

                return new RijndaelEncryptionServiceConfig { Key = key } as T;
            }

            return ConfigurationManager.GetSection(typeof(T).Name) as T;
        }
    }
}
