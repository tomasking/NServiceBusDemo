#region PlaceOrderHandler

using System;
using NServiceBus;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Two
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        IBus bus;

        public PlaceOrderHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(PlaceOrder message)
        {
            Console.WriteLine(@"PlaceOrder received, Product: {0}, Id: {1}", message.Product, message.Id);

//            Console.WriteLine(@"Publishing: OrderPlaced for Order Id: {0}", message.Id);
//
//            OrderPlaced orderPlaced = new OrderPlaced
//            {
//                OrderId = message.Id
//            };
//            bus.Publish(orderPlaced);
        }
    }
}

#endregion
