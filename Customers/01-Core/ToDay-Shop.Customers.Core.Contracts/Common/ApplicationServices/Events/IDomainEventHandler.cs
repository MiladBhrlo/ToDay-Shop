using ToDay_Shop.Customers.Core.Domain.Common.Events;

namespace ToDay_Shop.Customers.Core.Contracts.Common.ApplicationServices.Events;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}