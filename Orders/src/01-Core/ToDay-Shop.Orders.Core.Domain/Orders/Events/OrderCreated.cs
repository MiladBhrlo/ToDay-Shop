using ToDay_Shop.Orders.Core.Domain.Common.Events;

namespace ToDay_Shop.Orders.Core.Domain.Orders.Events;
public sealed class OrderCreated : IDomainEvent
{
    public long OrderId { get; set; }
    public Guid BusinessId { get; set; }
    public long CustomerId { get; set; }

    public DateTime OccurredOn => DateTime.UtcNow;
}
