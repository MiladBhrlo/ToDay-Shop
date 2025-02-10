namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.IntegrationEvents.OrderPaid;
public sealed class OrderPaidIntegrationEvent
{
    public long OrderId { get; set; }
    public Guid OrderBusinessId { get; set; }
}
