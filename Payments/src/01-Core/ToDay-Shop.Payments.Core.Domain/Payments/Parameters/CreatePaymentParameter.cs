using ToDay_Shop.Payments.Core.Domain.Payments.ValueObjects;

namespace ToDay_Shop.Payments.Core.Domain.Payments.Parameters;

public sealed record CreatePaymentParameter(long CustomerId,
                                            long OrderId,
                                            Price Price);
