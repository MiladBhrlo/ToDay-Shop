namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.IntegrationEvents.OrderCreated;
public sealed class OrderCreatedIntegrationEvent
{
    public long OrderId { get; set; }
    public Guid OrderBusinessId { get; set; }
    public long CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
}
