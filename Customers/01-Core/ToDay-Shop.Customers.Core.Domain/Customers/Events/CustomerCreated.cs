using ToDay_Shop.Customers.Core.Domain.Common.Events;

namespace ToDay_Shop.Customers.Core.Domain.Customers.Events;

public sealed class CustomerCreated : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}