using static ToDay_Shop.Payments.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.Pay;
public sealed class PayPaymentCommandResult
{
    public PaymentStatus Status { get; set; }
    public string PaymentStatusDescription { get; set; }
}
