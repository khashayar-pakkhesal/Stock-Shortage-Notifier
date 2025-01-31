namespace Domain.Notifications;

public interface INotificationService
{
    public ValueTask SendAsync(string message);
}