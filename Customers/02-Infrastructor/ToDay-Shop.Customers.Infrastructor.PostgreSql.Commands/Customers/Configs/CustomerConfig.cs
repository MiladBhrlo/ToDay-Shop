using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDay_Shop.Customers.Core.Domain.Customers.Entities;
using ToDay_Shop.Customers.Core.Resources.Constants;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Customers.Configs;
public sealed class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FirstName).HasMaxLength(ApplicationConsts.NameMaxLength).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(ApplicationConsts.NameMaxLength).IsRequired();

        //builder.HasIndex(c => c.BusinessId).IsUnique();
    }
}
