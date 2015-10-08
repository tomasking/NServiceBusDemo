
namespace NServiceBusDemo.Two
{
    using NServiceBus;

    using NServiceBusDemo.Messages;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.AssembliesToScan(typeof(PlaceOrderHandler).Assembly, typeof(OrderPlaced).Assembly);
            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();

            //// configuration.EndpointName("NServiceBus.Two");
            //// configuration.EnableInstallers();
        }
    }
}
