namespace ToDay_Shop.Customers.Core.Domain.Common.Events;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
