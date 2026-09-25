using System.Net.Http.Json;
using OrderService.API.Models;

namespace OrderService.API.Services;

public class NotificationServiceClient
    : INotificationServiceClient
{
    private readonly HttpClient _httpClient;

    public NotificationServiceClient(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendAsync(
        NotificationRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/notifications",
            request);

        response.EnsureSuccessStatusCode();
    }
}