using ToDay_Shop.Orders.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create.Dtos;

namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create;
public sealed class CreateOrderCommand : ICommand<long>
{
    public long CustomerId { get; set; }
    public List<CreateOrderItemDto> Items { get; set; } = new();
}
