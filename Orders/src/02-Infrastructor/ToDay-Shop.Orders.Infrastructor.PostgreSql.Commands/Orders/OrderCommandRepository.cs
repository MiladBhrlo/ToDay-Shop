using ToDay_Shop.Orders.Core.Contracts.Orders.Commands;
using ToDay_Shop.Orders.Core.Domain.Orders.Entities;
using ToDay_Shop.Orders.Infrastructor.PostgreSql.Commands.Common;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Commands.Orders;
public sealed class OrderCommandRepository : BaseCommandRepository<Order, OrdersCommandDbContext>,
        IOrderCommandRepository
{
    public OrderCommandRepository(OrdersCommandDbContext dbContext) : base(dbContext)
    {
    }
}

