namespace ToDay_Shop.Orders.Core.Domain.Orders.Parameters;

public sealed record CreateOrderParameter(long CustomerId,
                                          List<CreateOrderItemParameter>? ItemParameters);
