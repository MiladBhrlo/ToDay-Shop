using ToDay_Shop.Customers.Core.Domain.Common.Events;

namespace ToDay_Shop.Customers.Core.Contracts.Common.ApplicationServices.Events;
public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;
}
