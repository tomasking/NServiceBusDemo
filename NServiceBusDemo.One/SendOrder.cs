using System;

namespace NServiceBusDemo.One
{
    using NServiceBus;

    using NServiceBusDemo.Messages;
    using NServiceBusDemo.Messages.Commands;

    public class SendOrder
    {
        static void SendOrderToBus(IBus bus)
        {

            Console.WriteLine("Press enter to send a message");
            Console.WriteLine("Press any key to exit");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Enter)
                {
                    return;
                }
                Guid id = Guid.NewGuid();

                PlaceOrder placeOrder = new PlaceOrder
                {
                    Product = "New shoes",
                    Id = id
                };
                bus.Send("Samples.StepByStep.Server", placeOrder);

                Console.WriteLine("Sent a new PlaceOrder message with id: {0}", id.ToString("N"));

            }

        }
    } 
}
