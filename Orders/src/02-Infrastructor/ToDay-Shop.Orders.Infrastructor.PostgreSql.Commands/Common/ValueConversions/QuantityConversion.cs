using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDay_Shop.Orders.Core.Domain.Orders.ValueObjects;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Commands.Common.ValueConversions;
public sealed class QuantityConversion : ValueConverter<Quantity, int>
{
    public QuantityConversion() : base(quantity => quantity.Value, quantity => Quantity.FromInt(quantity))
    {
    }
}
