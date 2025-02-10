using ToDay_Shop.Customers.Core.Domain.Common.Events;

namespace ToDay_Shop.Customers.Core.Domain.Common.Entities;
public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();
}
