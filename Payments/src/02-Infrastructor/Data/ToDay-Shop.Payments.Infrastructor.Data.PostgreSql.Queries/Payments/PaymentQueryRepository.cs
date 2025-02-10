using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Payments.Core.Contracts.Payments.Queries;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Queries.GetAllCustomerPayments;
using ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Queries.Common;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Queries.Payments;
public sealed class PaymentQueryRepository : BaseQueryRepository<PaymentsQueryDbContext>, IPaymentQueryRepository
{
    public PaymentQueryRepository(PaymentsQueryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<PaymentSelectItemQr>> ExecuteAsync(GetAllCustomerPaymentsQuery query)
        => await _dbContext.Payments
            .Where(c => c.CustomerId == query.CustomerId)
            .Select(c => new PaymentSelectItemQr
            {
                PaymentId = c.Id,
                OrderId = c.OrderId,
                Status = c.Status,
                StatusDescription = c.Status.ToString(),
                Method = c.Method,
                MethodDescription = c.Method.ToString(),
                Price = new Random().Next(0, 10000), //
            }).ToListAsync();
}
