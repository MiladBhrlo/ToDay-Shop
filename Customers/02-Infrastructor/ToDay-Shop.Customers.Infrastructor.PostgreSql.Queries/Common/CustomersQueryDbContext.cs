using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Customers;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Common;
public sealed class CustomersQueryDbContext : BaseQueryDbContext
{
    public CustomersQueryDbContext(DbContextOptions<CustomersQueryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
}
