
namespace NServiceBusDemo.One
{
    using NHibernate.Cfg;

    using NServiceBus;
    using NServiceBus.Persistence;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<NHibernatePersistence, StorageType.Subscriptions>();
            configuration.UsePersistence<InMemoryPersistence, StorageType.Timeouts>();
            configuration.UseTransport<MsmqTransport>();
        }
    }
}
