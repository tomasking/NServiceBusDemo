
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Two
{
    using System.Reflection;

    using NServiceBus;
    using NServiceBus.Features;
    using NServiceBus.Persistence;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.AssembliesToScan(typeof(PlaceOrderHandler).Assembly, typeof(OrderPlaced).Assembly);
            configuration.EndpointName("PlaceOrder.Queue");
            configuration.UseSerialization<JsonSerializer>();
            configuration.EnableInstallers();
            configuration.UsePersistence<InMemoryPersistence>();
            
        }
    }
}
