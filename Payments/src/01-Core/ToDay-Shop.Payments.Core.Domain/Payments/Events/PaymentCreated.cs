using ToDay_Shop.Payments.Core.Domain.Common.Events;

namespace ToDay_Shop.Payments.Core.Domain.Payments.Events;
public sealed class PaymentCreated : IDomainEvent
{
    public long PaymentId { get; set; }
    public Guid BusinessId { get; set; }
    public long CustomerId { get; set; }
    public long OrderId { get; set; }
    public decimal Price { get; set; }

    public DateTime OccurredOn => DateTime.UtcNow;
}
