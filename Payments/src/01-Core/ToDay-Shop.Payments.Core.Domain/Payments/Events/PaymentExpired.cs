using ToDay_Shop.Payments.Core.Domain.Common.Events;

namespace ToDay_Shop.Payments.Core.Domain.Payments.Events;

public sealed class PaymentExpired : IDomainEvent
{
    public Guid BusinessId { get; set; }

    public DateTime OccurredOn => DateTime.UtcNow;
}
