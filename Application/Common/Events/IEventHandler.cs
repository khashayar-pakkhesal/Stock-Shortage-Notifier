namespace Application.Common.Events;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    public Task HandleEvent(TEvent publishedEvent, CancellationToken cancellationToken = default);
}