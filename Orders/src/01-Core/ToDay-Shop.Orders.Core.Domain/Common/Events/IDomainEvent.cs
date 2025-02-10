namespace ToDay_Shop.Orders.Core.Domain.Common.Events;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
