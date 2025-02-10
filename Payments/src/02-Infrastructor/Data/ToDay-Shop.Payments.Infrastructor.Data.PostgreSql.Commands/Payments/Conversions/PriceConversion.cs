using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDay_Shop.Payments.Core.Domain.Payments.ValueObjects;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Payments.Conversions;
public sealed class PriceConversion : ValueConverter<Price, decimal>
{
    public PriceConversion() : base(price => price.Value, price => Price.FromDecimal(price))
    {
    }
}
