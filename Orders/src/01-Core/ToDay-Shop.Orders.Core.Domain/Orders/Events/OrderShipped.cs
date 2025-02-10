using ToDay_Shop.Orders.Core.Domain.Common.Events;

namespace ToDay_Shop.Orders.Core.Domain.Orders.Events;

public sealed class OrderShipped : IDomainEvent
{
    public Guid BusinessId { get; set; }

    public DateTime OccurredOn => DateTime.UtcNow;
}