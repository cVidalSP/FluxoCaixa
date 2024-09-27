namespace FC.Caixa.Domain.Interfaces.MessageBroker
{
    public interface IEventBusPublisher
    {
        public interface IEventBusPublisher
        {
            Task Publish<TEvent>(TEvent @event);
        }
    }
}
