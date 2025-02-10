using FluentValidation;
using ToDay_Shop.Payments.Core.Resources.Constants;

namespace ToDay_Shop.Payments.Core.RequestResponse.Payments.Commands.Pay;
public sealed class PayPaymentValidator : AbstractValidator<PayPaymentCommand>
{
    public PayPaymentValidator()
    {
        RuleFor(c => c.PaymentId)
                .NotNull()
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED,
                                           ApplicationTranslationKey.PAYMENT_ID))
                .GreaterThan(0)
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_MUST_GREATER_THAN,
                                       ApplicationTranslationKey.PAYMENT_ID,
                                       0));
    }
}
