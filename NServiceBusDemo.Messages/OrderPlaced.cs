using System;
using NServiceBus;

namespace NServiceBusDemo.Messages
{
    public class OrderPlaced : IOrderPlaced, IEvent
    {
        public Guid OrderId { get; set; }
    }
}