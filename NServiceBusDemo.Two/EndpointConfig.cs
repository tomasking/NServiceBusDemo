
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
            configuration.AssembliesToScan(typeof(NHibernatePersistence).Assembly, typeof(PlaceOrderHandler).Assembly, typeof(OrderPlaced).Assembly);
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.UseSerialization<JsonSerializer>();
        }
    }
}
