using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDay_Shop.Payments.Core.Domain.Common.ValueObjects;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common.ValueConversions;

public class BusinessIdConversion : ValueConverter<BusinessId, Guid>
{
    public BusinessIdConversion() : base(c => c.Value, c => BusinessId.FromGuid(c))
    {

    }
}
