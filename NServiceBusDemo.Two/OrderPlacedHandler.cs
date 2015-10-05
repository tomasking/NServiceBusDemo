

#region OrderCreatedHandler
namespace NServiceBusDemo.Two
{
    using System;

    using NServiceBus;

    using NServiceBusDemo.Messages;

    public class OrderPlacedHandler : IHandleMessages<IOrderPlaced>
    {
        public IBus Bus { get; set; }


        public void Handle(IOrderPlaced message)
        {
            Console.WriteLine(@"Handling: OrderPlaceed for Order Id: {0}", message.OrderId);
        }
    }
}
#endregion