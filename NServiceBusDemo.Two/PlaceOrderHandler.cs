namespace NServiceBusDemo.Two
{
    using System;

    using NServiceBus;

    using NServiceBusDemo.Messages;

    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public PlaceOrderHandler()
        {
            int i = 4;
        }

        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Order for Product: {0} placed.", message.Product);
        }
    } 
}
