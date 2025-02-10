using ToDay_Shop.Customers.Core.Contracts.Common.Data.Queries;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.CommonResults;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.GetAll;

namespace ToDay_Shop.Customers.Core.Contracts.Customers.Queries;
public interface ICustomerQueryRepository : IQueryRepository
{
    public Task<List<CustomerQr>> ExecuteAsync(GetAllCustomersQuery query);
}
