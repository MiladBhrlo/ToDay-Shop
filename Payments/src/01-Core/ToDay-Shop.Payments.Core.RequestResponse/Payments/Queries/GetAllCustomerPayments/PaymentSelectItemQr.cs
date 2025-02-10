using static ToDay_Shop.Payments.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.Queries.GetAllCustomerPayments;
public sealed class PaymentSelectItemQr
{
    public long PaymentId { get; set; }
    public long OrderId { get; set; }
    public PaymentStatus Status { get; set; }
    public string StatusDescription { get; set; } = string.Empty;
    public PaymentMethod? Method { get; set; }
    public string? MethodDescription { get; set; }
    public decimal Price { get; set; }
}
