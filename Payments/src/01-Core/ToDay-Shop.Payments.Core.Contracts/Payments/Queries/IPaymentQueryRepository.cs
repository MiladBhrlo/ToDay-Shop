using ToDay_Shop.Payments.Core.Contracts.Common.Data.Queries;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Queries.GetAllCustomerPayments;

namespace ToDay_Shop.Payments.Core.Contracts.Payments.Queries;
public interface IPaymentQueryRepository : IQueryRepository
{
    public Task<List<PaymentSelectItemQr>> ExecuteAsync(GetAllCustomerPaymentsQuery query);
}
