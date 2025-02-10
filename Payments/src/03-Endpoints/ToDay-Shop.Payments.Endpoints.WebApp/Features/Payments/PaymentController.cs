using Microsoft.AspNetCore.Mvc;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.InProgress;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.Pay;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Queries.GetAllCustomerPayments;
using ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor;

namespace ToDay_Shop.Payments.Endpoints.WebApp.Features.Payments;

[Route("api/[controller]")]
public class PaymentController : BaseController
{
    #region Commands
    [HttpPost("[action]")]
    public async Task<IActionResult> InProgress([FromBody] InProgressPaymentCommand command)
        => await Create<InProgressPaymentCommand, long>(command);

    [HttpPost("[action]")]
    public async Task<IActionResult> Pay([FromBody] PayPaymentCommand command)
    => await Create<PayPaymentCommand, PayPaymentCommandResult>(command);

    #endregion

    #region Queries
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll(GetAllCustomerPaymentsQuery query)
        => await Query<GetAllCustomerPaymentsQuery, List<PaymentSelectItemQr>>(query);
    #endregion
}
