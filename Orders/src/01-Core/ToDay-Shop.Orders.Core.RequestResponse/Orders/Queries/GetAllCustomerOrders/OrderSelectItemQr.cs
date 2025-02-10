using static ToDay_Shop.Orders.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.Queries.GetAllCustomerOrders;
public sealed class OrderSelectItemQr
{
    public long OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public string StatusDescription { get; set; }
    public decimal TotalAmount { get; set; }
}
