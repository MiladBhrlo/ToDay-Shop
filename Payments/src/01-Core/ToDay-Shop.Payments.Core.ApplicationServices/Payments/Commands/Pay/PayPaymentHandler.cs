using MassTransit;
using ToDay_Shop.Payments.Core.ApplicationServices.Common.Commands;
using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Payments.Core.Contracts.Payments.Commands;
using ToDay_Shop.Payments.Core.Domain.Payments.Entities;
using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.Pay;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.IntegrationEvents.OrderPaid;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.IntegrationEvents.PaymentPaid;
using ToDay_Shop.Payments.Core.Resources.Constants;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards.GuardClauses;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Payments.Commands.Pay;

public sealed class PayPaymentHandler : CommandHandler<PayPaymentCommand, PayPaymentCommandResult>
{
    private readonly IPaymentCommandRepository _paymentCommandRepository;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IPublishEndpoint _publishEndpoint;

    public PayPaymentHandler(IPaymentCommandRepository paymentCommandRepository,
                             IEventDispatcher eventDispatcher,
                             IPublishEndpoint publishEndpoint)
    {
        _paymentCommandRepository = paymentCommandRepository;
        _eventDispatcher = eventDispatcher;
        _publishEndpoint = publishEndpoint;
    }

    public override async Task<CommandResult<PayPaymentCommandResult>> Handle(PayPaymentCommand command)
    {
        Payment? payment = await _paymentCommandRepository.GetAsync(command.PaymentId);
        Guard.ThrowIf.Null(payment, string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA,
                                                  ApplicationTranslationKey.PAYMENT_ID));

        payment.Success();

        await _paymentCommandRepository.CommitAsync();

        foreach (var orderEvent in payment.GetEvents().ToList())
        {
            await _eventDispatcher.PublishDomainEventAsync(orderEvent);
        }
        payment.ClearEvents();

        await _publishEndpoint.Publish(new PaymentPaidIntegrationEvent
        {
            PaymentId = payment.Id,
            PaymentBusinessId = payment.BusinessId.Value,
            CustomerId = payment.CustomerId,
            OrderId = payment.OrderId,
            PaymentSuccessDate = payment.PaymentSuccessDate!.Value,
        });

        await _publishEndpoint.Publish(new OrderPaidIntegrationEvent
        {
            OrderId = payment.OrderId,
            OrderBusinessId = Guid.NewGuid(),// temp :| must use order business id insted of order db id
        });

        return Ok(new PayPaymentCommandResult
        {
            Status = payment.Status,
            PaymentStatusDescription = payment.Status.ToString()
        });
    }
}
