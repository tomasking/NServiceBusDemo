using System;
using NServiceBus;

namespace NServiceBusDemo.Messages
{
    public class StartOrder : ICommand
    {
        public Guid Id { get; set; }

        public string OrderId { get; set; }
    }
}