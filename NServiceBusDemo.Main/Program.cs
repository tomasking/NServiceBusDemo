namespace NServiceBusDemo.Main
{
    using System;

    using NServiceBus;

    using NServiceBusDemo.Messages;
    using NServiceBusDemo.Messages.Commands;

    class Program
    {
        static void Main()
        {
            BusConfiguration busConfiguration = new BusConfiguration();
            
            busConfiguration.EndpointName("NServiceBusDemo.OrderPlaced"); // Optional - otherwise will take name of the project
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.UseSerialization<JsonSerializer>();

            // busConfiguration.EnableInstallers();
            
            using (IBus bus = Bus.Create(busConfiguration).Start())
            {
                while (true)
                {
                    Console.WriteLine("A) Send PlaceOrder Command");
                    Console.WriteLine("B) Send OrderPlacedEvent");
                    Console.WriteLine("Press Enter to exit");
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();

                    if (key.Key == ConsoleKey.A)
                    {
                        SendCommand(bus);
                    }
                    else if (key.Key == ConsoleKey.B)
                    {
                        PublishEvent(bus);
                    }
                    else
                    {
                        Console.WriteLine("UNRECOGNISED");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        private static void PublishEvent(IBus bus)
        {
            Guid id = Guid.NewGuid();
            OrderPlaced orderPlaced = new OrderPlaced
            {
                OrderId = id
            };
            bus.Publish(orderPlaced); // publishes to any subscribers that have registered with this endpoint as interested in this message
            Console.WriteLine("Published OrderPlaced ({0})", id.ToString("N"));
        }

        private static void SendCommand(IBus bus)
        {
            Guid id = Guid.NewGuid();
            PlaceOrder placeOrder = new PlaceOrder
            {
                Product = "New shoes",
                Id = id
            };
            bus.Send(placeOrder); // queue to send to defined in App.config for different assemblies

            Console.WriteLine("Sent PlaceOrder ({0})", id.ToString("N"));
        }
    }
}
