using ToDay_Shop.Payments.Core.Contracts.Common.Data.Commands;
using ToDay_Shop.Payments.Core.Domain.Payments.Entities;

namespace ToDay_Shop.Payments.Core.Contracts.Payments.Commands;
public interface IPaymentCommandRepository : ICommandRepository<Payment>
{
    Task<Payment?> GetByOrderId(long orderId);
}
