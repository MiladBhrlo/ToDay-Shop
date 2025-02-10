using FluentValidation;
using ToDay_Shop.Customers.Core.Resources.Constants;

namespace ToDay_Shop.Customers.Core.RequestResponse.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(c => c.FirstName)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED, ApplicationTranslationKey.FIRST_NAME))
            .MinimumLength(ApplicationConsts.NameMinLength)
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_STRING_MIN_LENGTH,
                                       ApplicationTranslationKey.FIRST_NAME,
                                       ApplicationConsts.NameMinLength))
            .MaximumLength(ApplicationConsts.NameMaxLength)
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_STRING_MAX_LENGTH,
                                       ApplicationTranslationKey.FIRST_NAME,
                                       ApplicationConsts.NameMaxLength));

        RuleFor(c => c.LastName)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_REQUIRED, ApplicationTranslationKey.LAST_NAME))
            .MinimumLength(ApplicationConsts.NameMinLength)
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_STRING_MIN_LENGTH,
                                       ApplicationTranslationKey.LAST_NAME,
                                       ApplicationConsts.NameMinLength))
            .MaximumLength(ApplicationConsts.NameMaxLength)
            .WithMessage(string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_STRING_MAX_LENGTH,
                                       ApplicationTranslationKey.LAST_NAME,
                                       ApplicationConsts.NameMaxLength));
    }
}
