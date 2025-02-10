using MassTransit;
using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Payments.Core.Contracts.Payments.Commands;
using ToDay_Shop.Payments.Core.Domain.Payments.Entities;
using ToDay_Shop.Payments.Core.Domain.Payments.Parameters;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.IntegrationEvents.OrderCreated;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Payments.Events.OrderCreated;
public sealed class OrderCreatedConsumer : IConsumer<OrderCreatedIntegrationEvent>
{
    private readonly IPaymentCommandRepository _paymentCommandRepository;
    private readonly IEventDispatcher _eventDispatcher;

    public OrderCreatedConsumer(IPaymentCommandRepository paymentCommandRepository,
                             IEventDispatcher eventDispatcher)
    {
        _paymentCommandRepository = paymentCommandRepository;
        _eventDispatcher = eventDispatcher;
    }
    public async Task Consume(ConsumeContext<OrderCreatedIntegrationEvent> context)
    {
        var payment = Payment.Create(new CreatePaymentParameter(context.Message.CustomerId,
                                                                context.Message.OrderId,
                                                                new Random().Next(1, 10000)));
        await _paymentCommandRepository.InsertAsync(payment);
        await _paymentCommandRepository.CommitAsync();

        foreach (var domainEvent in payment.GetEvents())
        {
            await _eventDispatcher.PublishDomainEventAsync(domainEvent);
        }

        payment.ClearEvents();
    }
}
