using FluentValidation;
using ToDay_Shop.Payments.Core.Resources.Constants;

namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.InProgress;

public sealed class InProgressPaymentValidator : AbstractValidator<InProgressPaymentCommand>
{
    public InProgressPaymentValidator()
    {
        RuleFor(c => c.OrderId)
                .NotNull()
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED,
                                           ApplicationTranslationKey.ORDER_ID))
                .GreaterThan(0)
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_MUST_GREATER_THAN,
                                           ApplicationTranslationKey.ORDER_ID,
                                           0));

        RuleFor(c => c.PaymentMethod)
            .IsInEnum()
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA,
                                       ApplicationTranslationKey.PAYMENT_METHOD));
    }
}
