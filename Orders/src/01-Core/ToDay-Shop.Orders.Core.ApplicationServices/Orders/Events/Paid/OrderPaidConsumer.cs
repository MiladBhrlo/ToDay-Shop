using MassTransit;
using ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Orders.Core.Contracts.Orders.Commands;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.IntegrationEvents.OrderPaid;

namespace ToDay_Shop.Orders.Core.ApplicationServices.Orders.Events.Paid;
public sealed class OrderPaidConsumer : IConsumer<OrderPaidIntegrationEvent>
{
    private readonly IOrderCommandRepository _orderCommandRepository;
    private readonly IEventDispatcher _eventDispatcher;

    public OrderPaidConsumer(IOrderCommandRepository orderCommandRepository,
                             IEventDispatcher eventDispatcher)
    {
        _orderCommandRepository = orderCommandRepository;
        _eventDispatcher = eventDispatcher;
    }
    public async Task Consume(ConsumeContext<OrderPaidIntegrationEvent> context)
    {
        // its better to use business id insted
        var order = await _orderCommandRepository.GetAsync(context.Message.OrderId);
        if (order is null)
            return;

        order.Paid();
        await _orderCommandRepository.CommitAsync();

        foreach (var domainEvent in order.GetEvents())
        {
            await _eventDispatcher.PublishDomainEventAsync(domainEvent);
        }

        order.ClearEvents();
    }
}
