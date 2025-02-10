using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Customers.Core.Domain.Customers.Entities;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Common;
public class CustomersCommandDbContext : BaseCommandDbContext
{
    public DbSet<Customer> Customers { get; set; }

    public CustomersCommandDbContext(DbContextOptions<CustomersCommandDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
