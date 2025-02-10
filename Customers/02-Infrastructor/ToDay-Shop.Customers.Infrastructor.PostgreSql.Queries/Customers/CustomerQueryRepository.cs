using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Customers.Core.Contracts.Customers.Queries;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.CommonResults;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.GetAll;
using ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Common;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Customers;
public sealed class CustomerQueryRepository : BaseQueryRepository<CustomersQueryDbContext>, ICustomerQueryRepository
{
    public CustomerQueryRepository(CustomersQueryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<CustomerQr>> ExecuteAsync(GetAllCustomersQuery query) 
        => await _dbContext.Customers.Select(c => new CustomerQr
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            }).ToListAsync();
}
