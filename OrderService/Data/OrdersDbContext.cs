using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;

namespace OrderService.Data;

public class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) 
        : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
}