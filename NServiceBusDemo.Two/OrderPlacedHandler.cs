
namespace NServiceBusDemo.Two
{
    using System;

    using NServiceBus;

    using NServiceBusDemo.Messages;

    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        public void Handle(OrderPlaced message)
        {
            Console.WriteLine(@"Handling: OrderPlaced ({0})", message.OrderId.ToString("N"));
        }
    }
}
