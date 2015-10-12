
using System;
using NHibernate.Cfg;
using NServiceBus.Features;
using NServiceBus.Persistence;
using NServiceBus.Persistence.NHibernate;

namespace NServiceBusDemo.Two
{
    using NServiceBus;

    using NServiceBusDemo.Messages;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            // configuration.DisableFeature<TimeoutManager>();
            configuration.AssembliesToScan(typeof(NHibernatePersistence).Assembly, typeof(PlaceOrderHandler).Assembly, typeof(OrderPlaced).Assembly);
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.UseSerialization<JsonSerializer>();
            configuration.DisableFeature<NHibernateTimeoutStorage>();

            //configuration.UsePersistence<InMemoryPersistence>();
            // configuration.EndpointName("NServiceBus.Two");
            // configuration.EnableInstallers();
        }
    }
}
