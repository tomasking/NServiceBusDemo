namespace NServiceBusDemo.One
{
    using NServiceBus;

    using NServiceBusDemo.Messages;

    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            this.Bus.Send("NServiceBusDemo.PlaceOrder", new PlaceOrder() { Product = "New shoes" });
        }

        public void Stop()
        {
        }
    } 
}
