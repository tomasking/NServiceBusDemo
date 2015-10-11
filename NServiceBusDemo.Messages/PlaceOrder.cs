﻿using System;
using NServiceBus;

namespace NServiceBusDemo.Messages
{
    public class PlaceOrder : ICommand
    {
        public Guid Id { get; set; }

        public string Product { get; set; }
    }
}
