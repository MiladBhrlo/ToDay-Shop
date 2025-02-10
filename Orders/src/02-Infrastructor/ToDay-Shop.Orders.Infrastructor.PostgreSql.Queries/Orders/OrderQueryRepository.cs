using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Orders.Core.Contracts.Orders.Queries;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Queries.GetAllCustomerOrders;
using ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Common;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Orders;
public sealed class OrderQueryRepository : BaseQueryRepository<OrdersQueryDbContext>, IOrderQueryRepository
{
    public OrderQueryRepository(OrdersQueryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<OrderSelectItemQr>> ExecuteAsync(GetAllCustomerOrdersQuery query) 
        => await _dbContext.Orders
            .Where(c => c.CustomerId == query.CustomerId)
            .Select(c => new OrderSelectItemQr
            {
                OrderId = c.Id,
                Status = c.Status,
                StatusDescription = c.Status.ToString(),
                TotalAmount = new Random().Next(0, 10000), //
            }).ToListAsync();
}
