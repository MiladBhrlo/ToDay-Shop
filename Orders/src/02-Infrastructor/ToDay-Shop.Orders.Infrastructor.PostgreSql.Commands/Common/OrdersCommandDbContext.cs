using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Orders.Core.Domain.Orders.Entities;
using ToDay_Shop.Orders.Core.Domain.Orders.ValueObjects;
using ToDay_Shop.Orders.Infrastructor.PostgreSql.Commands.Common.ValueConversions;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Commands.Common;
public class OrdersCommandDbContext : BaseCommandDbContext
{
    public DbSet<Order> Orders { get; set; }

    public OrdersCommandDbContext(DbContextOptions<OrdersCommandDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<Quantity>().HaveConversion<QuantityConversion>();
    }
}
