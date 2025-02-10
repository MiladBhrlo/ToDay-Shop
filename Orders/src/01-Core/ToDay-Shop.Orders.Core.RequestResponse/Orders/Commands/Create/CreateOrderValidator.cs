using FluentValidation;
using ToDay_Shop.Orders.Core.Resources.Constants;

namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create;
public sealed class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(c => c.CustomerId)
                .NotNull()
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED,
                                           ApplicationTranslationKey.CUSTOMER_ID))
                .GreaterThan(0)
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_MUST_GREATER_THAN,
                                       ApplicationTranslationKey.PRODUCT_ID,
                                       0));

        RuleFor(c => c.Items)
                .NotNull()
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED,
                                           ApplicationTranslationKey.ORDER_ITEM));
        RuleForEach(c => c.Items).SetValidator(new CreateOrderItemValidator());
    }
}
