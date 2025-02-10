using ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Queries.Common;
using static ToDay_Shop.Payments.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Queries.Payments.Entities;
public sealed class Payment : QueryObject
{
    public long CustomerId { get; set; }
    public long OrderId { get; set; }
    public PaymentStatus Status { get; set; }
    public PaymentMethod? Method { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal Price { get; set; }
    public DateTime? PaymentSuccessDate { get; set; }
}