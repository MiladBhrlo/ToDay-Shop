using ToDay_Shop.Customers.Core.Contracts.Common.Data.Commands;
using ToDay_Shop.Customers.Core.Domain.Customers.Entities;

namespace ToDay_Shop.Customers.Core.Contracts.Customers.Commands;
public interface ICustomerCommandRepository : ICommandRepository<Customer>
{
}
