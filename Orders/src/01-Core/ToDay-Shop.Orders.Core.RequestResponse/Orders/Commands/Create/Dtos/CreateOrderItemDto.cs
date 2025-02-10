namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create.Dtos;
public sealed class CreateOrderItemDto
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}
