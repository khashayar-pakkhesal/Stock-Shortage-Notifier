namespace Application.Common.Events;

public interface IEventDispatcher
{
    public Task DispatchAsync<TEvent>(TEvent toPublishEvent, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}