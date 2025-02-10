using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Queries.Payments.Entities;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Queries.Common;
public sealed class PaymentsQueryDbContext : BaseQueryDbContext
{
    public PaymentsQueryDbContext(DbContextOptions<PaymentsQueryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Payment> Payments { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
}
