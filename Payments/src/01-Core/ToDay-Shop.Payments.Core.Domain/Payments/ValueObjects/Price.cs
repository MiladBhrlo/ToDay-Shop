using ToDay_Shop.Payments.Core.Domain.Common.ValueObjects;
using ToDay_Shop.Payments.Core.Resources.Constants;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards.GuardClauses;

namespace ToDay_Shop.Payments.Core.Domain.Payments.ValueObjects;
public sealed class Price : BaseValueObject<Price>
{
    public static Price FromDecimal(decimal value) => new(value);

    public Price(decimal value)
    {
        Guard.ThrowIf.GreaterThanOrEqual(value: value,
                                         minimumValue: 0,
                                         message: string.Format(ApplicationValidationError.VALIDATION_ERROR_MUST_GREATER_THAN_OR_EQUAL,
                                                                nameof(Price),
                                                                0));

        Value = value;
    }

    private Price()
    {
    }

    public decimal Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator decimal(Price quantity) => quantity.Value;
    public static implicit operator Price(decimal value) => new(value);
}