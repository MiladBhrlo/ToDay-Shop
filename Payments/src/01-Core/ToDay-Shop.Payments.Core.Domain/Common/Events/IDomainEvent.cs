using MediatR;

namespace ToDay_Shop.Payments.Core.Domain.Common.Events;
public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}
