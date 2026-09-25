using Microsoft.AspNetCore.Mvc;
using NotificationService.API.Models;

namespace NotificationService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    [HttpPost]
    public IActionResult Send(NotificationRequest request)
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("NEW NOTIFICATION");
        Console.WriteLine($"Order Id: {request.OrderId}");
        Console.WriteLine($"Product: {request.ProductName}");
        Console.WriteLine($"Quantity: {request.Quantity}");
        Console.WriteLine($"Total: {request.TotalPrice} AZN");
        Console.WriteLine("----------------------------------");

        return Ok(new
        {
            message = "Notification sent successfully."
        });
    }
}