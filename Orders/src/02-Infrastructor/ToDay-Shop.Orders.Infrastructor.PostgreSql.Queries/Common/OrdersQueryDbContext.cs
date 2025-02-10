using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Orders.Entities;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Common;
public sealed class OrdersQueryDbContext : BaseQueryDbContext
{
    public OrdersQueryDbContext(DbContextOptions<OrdersQueryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
}
