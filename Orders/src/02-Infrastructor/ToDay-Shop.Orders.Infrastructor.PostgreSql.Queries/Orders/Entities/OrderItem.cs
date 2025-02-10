namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Orders.Entities;
public sealed class OrderItem
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}
