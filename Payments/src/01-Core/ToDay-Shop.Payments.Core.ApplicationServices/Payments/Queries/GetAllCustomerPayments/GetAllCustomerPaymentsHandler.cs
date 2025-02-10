using ToDay_Shop.Payments.Core.ApplicationServices.Common.Queries;
using ToDay_Shop.Payments.Core.Contracts.Payments.Queries;
using ToDay_Shop.Payments.Core.RequestResponse.Common.Queries;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Queries.GetAllCustomerPayments;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Payments.Queries.GetAllCustomerPayments;
public sealed class GetAllCustomerPaymentsHandler : QueryHandler<GetAllCustomerPaymentsQuery, List<PaymentSelectItemQr>>
{
    private readonly IPaymentQueryRepository _paymentQueryRepository;

    public GetAllCustomerPaymentsHandler(IPaymentQueryRepository paymentQueryRepository)
    {
        _paymentQueryRepository = paymentQueryRepository;
    }

    public override async Task<QueryResult<List<PaymentSelectItemQr>>> Handle(GetAllCustomerPaymentsQuery query)
        => Result(await _paymentQueryRepository.ExecuteAsync(query));
}