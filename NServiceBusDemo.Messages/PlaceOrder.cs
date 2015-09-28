using System;

namespace NServiceBusDemo.Messages
{
    using NServiceBus;

    public class PlaceOrder : ICommand
    {
        public Guid Id { get; set; }

        public string Product { get; set; }
    }

}
