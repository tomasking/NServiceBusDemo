using System;
using System.Net.Mail;
using NServiceBus;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Main
{
    class Program
    {
        static void Main()
        {
            BusConfiguration busConfiguration = new BusConfiguration();
            //busConfiguration.EndpointName("PlaceOrder.Queue");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<InMemoryPersistence>();

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
                        SendEvent(bus);
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

        private static void SendEvent(IBus bus)
        {
            Guid id = Guid.NewGuid();
            OrderPlaced orderPlaced = new OrderPlaced
            {
                OrderId = id
            };
            bus.Publish(orderPlaced);
            Console.WriteLine("Published a new OrderPlaced event with OrderId: {0}", id.ToString("N"));
        }

        private static void SendCommand(IBus bus)
        {
            Guid id = Guid.NewGuid();
            PlaceOrder placeOrder = new PlaceOrder
            {
                Product = "New shoes",
                Id = id
            };
            bus.Send("PlaceOrder.Queue", placeOrder);

            Console.WriteLine("Sent a new PlaceOrder command with id: {0}", id.ToString("N"));
        }
    }
}
