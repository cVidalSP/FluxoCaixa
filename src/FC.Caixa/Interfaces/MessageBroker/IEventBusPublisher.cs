namespace FC.Caixa.Interfaces.MessageBroker
{
    public interface IEventBusPublisher
    {
        public interface IEventBusPublisher
        {
            Task Publish<TEvent>(TEvent @event);
        }
    }
}
