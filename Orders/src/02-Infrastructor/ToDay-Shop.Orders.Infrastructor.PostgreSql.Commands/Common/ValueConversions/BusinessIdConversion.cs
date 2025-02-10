using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDay_Shop.Orders.Core.Domain.Common.ValueObjects;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Commands.Common.ValueConversions;

public class BusinessIdConversion : ValueConverter<BusinessId, Guid>
{
    public BusinessIdConversion() : base(c => c.Value, c => BusinessId.FromGuid(c))
    {

    }
}
