using ToDay_Shop.Customers.Core.Resources.Constants;
using ToDay_Shop.Customers.Core.Resources.Utilities.Guards;
using ToDay_Shop.Customers.Core.Resources.Utilities.Guards.GuardClauses;

namespace ToDay_Shop.Customers.Core.Domain.Common.ValueObjects;
public class Name : BaseValueObject<Name>
{
    public static Name FromString(string value) => new(value);

    public Name(string value)
    {
        Guard.ThrowIf.NotEmpty(value,
                               string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA,
                                             nameof(Name)));

        Guard.ThrowIf.ExclusiveBetween(value.Length,
                                       ApplicationConsts.NameMinLength,
                                       ApplicationConsts.NameMaxLength,
                                       string.Format(ApplicationValidationError.VALIDATION_ERROR_INVALID_STRING_LENGTH_BETWEEN,
                                                     nameof(Name),
                                                     ApplicationConsts.NameMinLength,
                                                     ApplicationConsts.NameMaxLength));

        Value = value;
    }
    private Name()
    {

    }

    public string Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator string(Name name) => name.Value.ToString();
    public static implicit operator Name(string value) => new(value);
}
