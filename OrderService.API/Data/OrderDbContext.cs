using Microsoft.EntityFrameworkCore;
using OrderService.API.Models;
using System.Collections.Generic;

namespace OrderService.API.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();
}