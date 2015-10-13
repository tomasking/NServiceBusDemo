using System;
using NServiceBus.Saga;

namespace NServiceBusDemo.Saga
{
    public class OrderSagaData : IContainSagaData
    {
        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }
        [Unique]
        public virtual string OrderId { get; set; }
    }
}