using ToDay_Shop.Payments.Core.RequestResponse.Common;
using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;

namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.Pay;
public sealed class PayPaymentCommand : ICommand<PayPaymentCommandResult>, IWebRequest
{
    public long PaymentId { get; set; }

    public string Path => "/Api/Payments/Paid";
}
