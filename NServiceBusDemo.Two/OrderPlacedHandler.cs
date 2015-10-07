

#region OrderCreatedHandler
namespace NServiceBusDemo.Two
{
    using System;

    using NServiceBus;

    using NServiceBusDemo.Messages;

    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        public OrderPlacedHandler()
        {
            Console.WriteLine("ctro");
        }

        public void Handle(OrderPlaced message)
        {
            Console.WriteLine(@"Handling: OrderPlaceed for Order Id: {0}", message.OrderId);
        }
    }
}
#endregion