namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.IntegrationEvents.PaymentExpired;
public sealed class PaymentExpiredIntegrationEvent
{
    public long OrderId { get; set; }
    public Guid OrderBusinessId { get; set; }
}
