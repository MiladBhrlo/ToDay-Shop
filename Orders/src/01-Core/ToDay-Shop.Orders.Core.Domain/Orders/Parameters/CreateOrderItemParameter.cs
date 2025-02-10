using ToDay_Shop.Orders.Core.Domain.Orders.ValueObjects;

namespace ToDay_Shop.Orders.Core.Domain.Orders.Parameters;

public sealed record CreateOrderItemParameter(long ProductId, Quantity Quantity);
