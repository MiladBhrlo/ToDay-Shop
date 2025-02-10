using ToDay_Shop.Payments.Core.Domain.Common.Events;

namespace ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Events;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}