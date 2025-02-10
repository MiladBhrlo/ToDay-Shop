using ToDay_Shop.Orders.Core.Contracts.Common.Data.Commands;
using ToDay_Shop.Orders.Core.Domain.Orders.Entities;

namespace ToDay_Shop.Orders.Core.Contracts.Orders.Commands;
public interface IOrderCommandRepository : ICommandRepository<Order>
{
}
