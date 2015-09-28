using System;

namespace NServiceBusDemo.Messages
{
    public interface IOrderPlaced
    {
        Guid OrderId { get; set;}
    }
}