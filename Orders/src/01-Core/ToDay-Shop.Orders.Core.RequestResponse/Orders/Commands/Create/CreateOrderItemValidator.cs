using FluentValidation;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create.Dtos;
using ToDay_Shop.Orders.Core.Resources.Constants;

namespace ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create;
public sealed class CreateOrderItemValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemValidator()
    {
        RuleFor(c => c.ProductId)
                .NotNull()
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED,
                                       ApplicationTranslationKey.PRODUCT_ID))
                .GreaterThan(0)
                .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_MUST_GREATER_THAN,
                                       ApplicationTranslationKey.PRODUCT_ID,
                                       0));

        RuleFor(c => c.Quantity)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED,
                                       ApplicationTranslationKey.QUANTITY))
            .GreaterThan(0)
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_MUST_GREATER_THAN,
                                       ApplicationTranslationKey.QUANTITY,
                                       0));
    }
}
