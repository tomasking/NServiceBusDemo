namespace NServiceBusDemo.Messages
{
    using System;

    using NServiceBus;

    public class OrderPlaced : IOrderPlaced, IEvent
    {
        public Guid OrderId { get; set; }
    }
}