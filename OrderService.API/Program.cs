using Microsoft.EntityFrameworkCore;
using OrderService.API.Data;
using OrderService.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"));
});

builder.Services.AddHttpClient<
    IProductServiceClient,
    ProductServiceClient>(client =>
    {
        client.BaseAddress = new Uri(
            builder.Configuration[
                "Services:ProductService"]!);
    });

builder.Services.AddHttpClient<
    INotificationServiceClient,
    NotificationServiceClient>(client =>
    {
        client.BaseAddress = new Uri(
            builder.Configuration[
                "Services:NotificationService"]!);
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();