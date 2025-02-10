using MediatR;
using ToDay_Shop.Payments.Core.Domain.Common.Events;

namespace ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Events;

public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent, INotification;
}
