using ToDay_Shop.Payments.Core.ApplicationServices.Common.Commands;
using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Payments.Core.Contracts.Payments.Commands;
using ToDay_Shop.Payments.Core.Domain.Payments.Entities;
using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.InProgress;
using ToDay_Shop.Payments.Core.Resources.Constants;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards.GuardClauses;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Payments.Commands.InProgress;
public sealed class InProgressPaymentHandler : CommandHandler<InProgressPaymentCommand, long>
{
    private readonly IPaymentCommandRepository _paymentCommandRepository;
    private readonly IEventDispatcher _eventDispatcher;

    public InProgressPaymentHandler(IPaymentCommandRepository paymentCommandRepository, IEventDispatcher eventDispatcher)
    {
        _paymentCommandRepository = paymentCommandRepository;
        _eventDispatcher = eventDispatcher;
    }

    public override async Task<CommandResult<long>> Handle(InProgressPaymentCommand command)
    {
        Payment? payment = await _paymentCommandRepository.GetByOrderId(command.OrderId);
        Guard.ThrowIf.Null(payment, string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA,
                                                  ApplicationTranslationKey.ORDER_ID));

        payment.InProgress(command.PaymentMethod);

        await _paymentCommandRepository.CommitAsync();

        foreach (var orderEvent in payment.GetEvents().ToList())
        {
            await _eventDispatcher.PublishDomainEventAsync(orderEvent);
        }
        payment.ClearEvents();

        return Ok(payment.Id);
    }
}
