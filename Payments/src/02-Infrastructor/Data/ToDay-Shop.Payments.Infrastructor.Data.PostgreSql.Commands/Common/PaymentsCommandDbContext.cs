using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Payments.Core.Domain.Payments.Entities;
using ToDay_Shop.Payments.Core.Domain.Payments.ValueObjects;
using ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Payments.Conversions;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common;
public class PaymentsCommandDbContext : BaseCommandDbContext
{
    public DbSet<Payment> Payments { get; set; }

    public PaymentsCommandDbContext(DbContextOptions<PaymentsCommandDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<Price>().HaveConversion<PriceConversion>();
    }
}
