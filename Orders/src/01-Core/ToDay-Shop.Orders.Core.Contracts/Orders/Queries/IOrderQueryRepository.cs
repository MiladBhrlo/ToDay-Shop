using ToDay_Shop.Orders.Core.Contracts.Common.Data.Queries;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Queries.GetAllCustomerOrders;

namespace ToDay_Shop.Orders.Core.Contracts.Orders.Queries;
public interface IOrderQueryRepository : IQueryRepository
{
    public Task<List<OrderSelectItemQr>> ExecuteAsync(GetAllCustomerOrdersQuery query);
}
