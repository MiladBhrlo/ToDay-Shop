using ToDay_Shop.Customers.Core.Contracts.Customers.Commands;
using ToDay_Shop.Customers.Core.Domain.Customers.Entities;
using ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Common;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Customers;
public sealed class CustomerCommmandRepository : BaseCommandRepository<Customer, CustomersCommandDbContext>,
        ICustomerCommandRepository
{
    public CustomerCommmandRepository(CustomersCommandDbContext dbContext) : base(dbContext)
    {
    }
}
