using Domain.Notifications;

namespace Infrastructure.Services;

public class ConsoleNotifierService : INotificationService
{
    public ValueTask SendAsync(string message)
    {
        Console.WriteLine(message);
        return new ValueTask();
    }
}