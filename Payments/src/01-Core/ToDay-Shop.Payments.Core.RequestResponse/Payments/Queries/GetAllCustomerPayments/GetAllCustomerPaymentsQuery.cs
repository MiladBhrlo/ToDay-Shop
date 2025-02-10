using ToDay_Shop.Payments.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.Queries.GetAllCustomerPayments;
public sealed class GetAllCustomerPaymentsQuery : IQuery<List<PaymentSelectItemQr>>
{
    public long CustomerId { get; set; }
}
