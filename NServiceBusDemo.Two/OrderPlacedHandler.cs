using System;
using NServiceBus;
using NServiceBusDemo.Messages;

#region OrderCreatedHandler
namespace NServiceBusDemo.Two
{
    public class OrderPlacedHandler : IHandleMessages<IOrderPlaced>
    {
        public void Handle(IOrderPlaced message)
        {
            Console.WriteLine(@"Handling: OrderPlaceed for Order Id: {0}", message.OrderId);
        }
    }
}
#endregion