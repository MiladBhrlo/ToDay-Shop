using ToDay_Shop.Orders.Core.Domain.Common.Events;

namespace ToDay_Shop.Orders.Core.Domain.Orders.Events;
public sealed class OrderItemCreated : IDomainEvent
{
    public Guid BusinessId { get; set; }
    public Guid OrderBusinessId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }

    public DateTime OccurredOn => DateTime.UtcNow;
}
