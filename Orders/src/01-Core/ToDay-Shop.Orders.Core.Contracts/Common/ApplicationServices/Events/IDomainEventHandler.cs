using ToDay_Shop.Orders.Core.Domain.Common.Events;

namespace ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Events;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}