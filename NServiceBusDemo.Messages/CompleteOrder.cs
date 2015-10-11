using System;
using NServiceBus;

namespace NServiceBusDemo.Messages
{
    public class CompleteOrder : ICommand
    {
        public Guid Id { get; set; }

        public string OrderId { get; set; }
    }
}