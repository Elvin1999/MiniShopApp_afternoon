using OrderService.API.Models;

namespace OrderService.API.Services;

public interface INotificationServiceClient
{
    Task SendAsync(NotificationRequest request);
}