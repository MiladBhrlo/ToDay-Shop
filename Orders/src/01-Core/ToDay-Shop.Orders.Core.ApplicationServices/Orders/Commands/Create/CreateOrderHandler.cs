using MassTransit;
using ToDay_Shop.Orders.Core.ApplicationServices.Common.Commands;
using ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Orders.Core.Contracts.Orders.Commands;
using ToDay_Shop.Orders.Core.Domain.Orders.Entities;
using ToDay_Shop.Orders.Core.Domain.Orders.Parameters;
using ToDay_Shop.Orders.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.IntegrationEvents.OrderCreated;

namespace ToDay_Shop.Orders.Core.ApplicationServices.Orders.Commands.Create;
public sealed class CreateOrderHandler : CommandHandler<CreateOrderCommand, long>
{
    private readonly IOrderCommandRepository _orderCommandRepository;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateOrderHandler(IOrderCommandRepository orderCommandRepository, IEventDispatcher eventDispatcher, IPublishEndpoint publishEndpoint)
    {
        _orderCommandRepository = orderCommandRepository;
        _eventDispatcher = eventDispatcher;
        _publishEndpoint = publishEndpoint;
    }

    public override async Task<CommandResult<long>> Handle(CreateOrderCommand command)
    {
        var orderItemParameters = command.Items
            .Select(x => new CreateOrderItemParameter(x.ProductId, x.Quantity))
            .ToList();

        Order order = Order.Create(new CreateOrderParameter(command.CustomerId, orderItemParameters));

        await _orderCommandRepository.InsertAsync(order);
        await _orderCommandRepository.CommitAsync();

        foreach (var orderEvent in order.GetEvents().ToList())
        {
            await _eventDispatcher.PublishDomainEventAsync(orderEvent);
        }
        order.ClearEvents();

        await _publishEndpoint.Publish(new OrderCreatedIntegrationEvent
        {
            OrderId = order.Id,
            CustomerId = order.CustomerId,
            OrderBusinessId = order.BusinessId.Value,
            CreatedAt = DateTime.UtcNow
        });

        return Ok(order.Id);
    }
}
