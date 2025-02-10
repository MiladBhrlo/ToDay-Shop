using MediatR;
using ToDay_Shop.Orders.Core.Domain.Common.Events;

namespace ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Events;

public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent, INotification;
}
