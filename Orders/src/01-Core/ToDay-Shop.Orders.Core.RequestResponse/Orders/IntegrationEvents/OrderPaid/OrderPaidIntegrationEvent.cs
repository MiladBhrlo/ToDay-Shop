namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.IntegrationEvents.OrderPaid;
public sealed class OrderPaidIntegrationEvent
{
    public long OrderId { get; set; }
    public Guid OrderBusinessId { get; set; }
}
