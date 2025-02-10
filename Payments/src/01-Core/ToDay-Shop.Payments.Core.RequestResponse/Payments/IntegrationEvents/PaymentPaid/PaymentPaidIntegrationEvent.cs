namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.IntegrationEvents.PaymentPaid;
public sealed class PaymentPaidIntegrationEvent
{
    public long PaymentId { get; set; }
    public Guid PaymentBusinessId { get; set; }
    public long CustomerId { get; set; }
    public long OrderId { get; set; }
    public DateTime PaymentSuccessDate { get; set; }
}
