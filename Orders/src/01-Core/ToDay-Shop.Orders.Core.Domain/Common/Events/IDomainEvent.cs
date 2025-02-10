using MediatR;

namespace ToDay_Shop.Orders.Core.Domain.Common.Events;
public interface IDomainEvent: INotification
{
    DateTime OccurredOn { get; }
}
