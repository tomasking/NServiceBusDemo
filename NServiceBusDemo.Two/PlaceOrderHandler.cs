using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Two
{
    using System;

    using NServiceBus;

    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public void Handle(PlaceOrder message)
        {
            Console.WriteLine(@"Handling PlaceOrder ({0})", message.Id.ToString("N"));
        }
    }
}
