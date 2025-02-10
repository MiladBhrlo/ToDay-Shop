using ToDay_Shop.Orders.Core.ApplicationServices.Common.Commands;
using ToDay_Shop.Orders.Core.Contracts.Orders.Commands;
using ToDay_Shop.Orders.Core.Domain.Orders.Entities;
using ToDay_Shop.Orders.Core.Domain.Orders.Parameters;
using ToDay_Shop.Orders.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create;

namespace ToDay_Shop.Orders.Core.ApplicationServices.Orders.Commands.Create;
public sealed class CreateOrderHandler : CommandHandler<CreateOrderCommand, long>
{
    private readonly IOrderCommandRepository _orderCommandRepository;

    public CreateOrderHandler(IOrderCommandRepository orderCommandRepository)
    {
        _orderCommandRepository = orderCommandRepository;
    }

    public override async Task<CommandResult<long>> Handle(CreateOrderCommand command)
    {
        var orderItemParameters = command.Items
            .Select(x => new CreateOrderItemParameter(x.ProductId, x.Quantity))
            .ToList();

        Order order = Order.Create(new CreateOrderParameter(command.CustomerId, orderItemParameters));

        await _orderCommandRepository.InsertAsync(order);
        await _orderCommandRepository.CommitAsync();

        return Ok(order.Id);
    }
}
