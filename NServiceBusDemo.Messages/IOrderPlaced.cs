namespace NServiceBusDemo.Messages
{
    using System;

    public interface IOrderPlaced
    {
        Guid OrderId { get; set;}
    }
}