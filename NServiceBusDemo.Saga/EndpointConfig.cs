namespace NServiceBusDemo.Saga
{
    using NHibernate.Cfg;

    using NServiceBus;
    using NServiceBus.Features;
    using NServiceBus.Persistence;

    using NServiceBusDemo.Messages;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.DisableFeature<TimeoutManager>();
            configuration.AssembliesToScan(typeof(NHibernatePersistence).Assembly, typeof(OrderSaga).Assembly, typeof(OrderPlaced).Assembly);
            //configuration.UsePersistence<InMemoryPersistence>();
           
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.UseSerialization<JsonSerializer>();
            
            //configuration.DisableFeature<NHibernateTimeoutStorage>();
        }
    }
}
