using NHibernate.Cfg;
using NServiceBus.Persistence;

namespace NServiceBusDemo.Main
{
    using System;

    using NServiceBus;

    using NServiceBusDemo.Messages;

    class Program
    {
        static void Main()
        {
            BusConfiguration busConfiguration = new BusConfiguration();
            
            busConfiguration.EndpointName("NServiceBusDemo.OrderPlaced"); // Optional - otherwise will take name of the project
                                                                          
            //busConfiguration.UsePersistence<InMemoryPersistence>();
//            Configuration nhConfiguration = new Configuration();
//            nhConfiguration.Properties["dialect"] = "NHibernate.Dialect.MsSql2012Dialect";
//            nhConfiguration.Properties["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
//            nhConfiguration.Properties["connection.driver_class"] = "NHibernate.Driver.Sql2008ClientDriver";
            busConfiguration.UsePersistence<NHibernatePersistence>(); //.UseConfiguration(nhConfiguration);
            busConfiguration.UseSerialization<JsonSerializer>();
            
            using (IBus bus = Bus.Create(busConfiguration).Start())
            {
                while (true)
                {
                    Console.WriteLine("A) Send PlaceOrder Command");
                    Console.WriteLine("B) Publish OrderPlacedEvent");
                    Console.WriteLine("C) Send StartOrder");
                    Console.WriteLine("D) Send CompleteOrder");
                    Console.WriteLine("Press Enter to exit");
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();

                    Guid id = Guid.NewGuid();
                    if (key.Key == ConsoleKey.A)
                    {
                        PlaceOrder placeOrder = new PlaceOrder
                        {
                            Product = "New shoes",
                            Id = id
                        };
                        SendCommand(bus, placeOrder);
                    }
                    else if (key.Key == ConsoleKey.B)
                    {
                        var orderPlaced = new OrderPlaced { OrderId = id };
                        PublishEvent(bus, orderPlaced);
                    }
                    else if (key.Key == ConsoleKey.C)
                    {
                        var startOrder= new StartOrder { Id = id, OrderId = "123"};
                        SendCommand(bus, startOrder);
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        var completeOrder = new CompleteOrder { Id = id, OrderId = "123" };
                        SendCommand(bus, completeOrder);
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

        private static void PublishEvent<T>(IBus bus, T message)
        {
            bus.Publish(message); // publishes to any subscribers that have registered with this endpoint as interested in this message
            Console.WriteLine("Published {0}", typeof(T).Name);
        }

        private static void SendCommand<T>(IBus bus, T message)
        {
            bus.Send(message); // queue to send to defined in App.config for different assemblies
            Console.WriteLine("Sent {0}", typeof(T));
        }
    }
}
