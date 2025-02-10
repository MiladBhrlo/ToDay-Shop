using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDay_Shop.Orders.Core.Domain.Orders.Entities;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Commands.Orders.Configs;
public sealed class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(c => c.Items).WithOne()
             .HasPrincipalKey(c => c.Id).HasForeignKey(c => c.OrderId);

        //builder.HasIndex(c => c.BusinessId).IsUnique();
    }
}
