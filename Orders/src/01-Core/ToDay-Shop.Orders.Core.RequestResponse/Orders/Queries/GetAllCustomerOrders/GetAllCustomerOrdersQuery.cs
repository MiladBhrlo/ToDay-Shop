using ToDay_Shop.Orders.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.Queries.GetAllCustomerOrders;
public sealed class GetAllCustomerOrdersQuery : IQuery<List<OrderSelectItemQr>>
{
    public long CustomerId { get; set; }
}
