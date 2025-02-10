using ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Common;
using static ToDay_Shop.Orders.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Orders.Entities;
public sealed class Order : QueryObject
{
    public long CustomerId { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}
