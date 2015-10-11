using System;
using NServiceBus;
using NServiceBus.Saga;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Saga
{
    public class OrderSaga : Saga<OrderSagaData>,
        IAmStartedByMessages<StartOrder>,
        IHandleMessages<CompleteOrder>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderSagaData> mapper)
        {
            mapper.ConfigureMapping<StartOrder>(s => s.OrderId).ToSaga(m => m.OrderId);
            mapper.ConfigureMapping<CompleteOrder>(s => s.OrderId).ToSaga(m => m.OrderId);
        }
        
        public void Handle(StartOrder message)
        {
            Console.WriteLine("Handling: StartOrder OrderId {0}", message.OrderId);
            Data.OrderId = message.OrderId;
        }

        public void Handle(CompleteOrder message)
        {
            Console.WriteLine("Handling: CompleteOrder OrderId {0}", message.OrderId);
            // code to handle order completion
            MarkAsComplete();
        }
    }
}