using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Payments.Core.Contracts.Payments.Commands;
using ToDay_Shop.Payments.Core.Domain.Payments.Entities;
using ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Payments;
public sealed class PaymentCommandRepository : BaseCommandRepository<Payment, PaymentsCommandDbContext>,
        IPaymentCommandRepository
{
    public PaymentCommandRepository(PaymentsCommandDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Payment?> GetByOrderId(long orderId)
        => await _dbContext.Payments.FirstOrDefaultAsync(c => c.OrderId == orderId);
}

