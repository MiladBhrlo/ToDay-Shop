using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Payments.Core.RequestResponse.Common;
using static ToDay_Shop.Payments.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.InProgress;
public sealed class InProgressPaymentCommand : ICommand<long>, IWebRequest
{
    public long OrderId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public string Path => "/Api/Payments/InProgress";
}
