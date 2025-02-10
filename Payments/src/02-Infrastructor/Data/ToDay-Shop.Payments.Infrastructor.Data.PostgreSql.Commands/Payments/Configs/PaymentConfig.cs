using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDay_Shop.Payments.Core.Domain.Payments.Entities;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Payments.Configs;
public sealed class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasIndex(c => c.OrderId).IsUnique();
    }
}
