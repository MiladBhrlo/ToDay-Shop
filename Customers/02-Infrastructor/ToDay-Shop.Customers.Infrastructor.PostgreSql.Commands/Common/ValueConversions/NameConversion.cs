using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDay_Shop.Customers.Core.Domain.Common.ValueObjects;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Common.ValueConversions;
public sealed class NameConversion : ValueConverter<Name, string>
{
    public NameConversion() : base(name => name.Value, name => Name.FromString(name))
    {
    }
}
