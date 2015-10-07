
namespace NServiceBusDemo.Two
{
    using System;

    using NServiceBus;

    using NServiceBusDemo.Messages;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.AssembliesToScan(typeof(PlaceOrderHandler).Assembly, typeof(OrderPlaced).Assembly);
            configuration.EndpointName("NServiceBus.Two");
            configuration.UseSerialization<JsonSerializer>();
            configuration.EnableInstallers();
            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
