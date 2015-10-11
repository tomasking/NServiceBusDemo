using System;
using NServiceBus.Saga;

namespace NServiceBusDemo.Saga
{
    public class OrderSagaData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        [Unique]
        public string OrderId { get; set; }
    }
}