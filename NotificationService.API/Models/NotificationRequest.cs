namespace NotificationService.API.Models;

public class NotificationRequest
{
    public int OrderId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }
}