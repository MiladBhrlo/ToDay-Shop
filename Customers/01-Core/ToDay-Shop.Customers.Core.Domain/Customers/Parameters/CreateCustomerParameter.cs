using ToDay_Shop.Customers.Core.Domain.Common.ValueObjects;

namespace ToDay_Shop.Customers.Core.Domain.Customers.Parameters;

public sealed record CreateCustomerParameter(Name FirstName, Name LastName);