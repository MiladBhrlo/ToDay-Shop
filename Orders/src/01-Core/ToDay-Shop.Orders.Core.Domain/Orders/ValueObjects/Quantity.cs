using ToDay_Shop.Orders.Core.Domain.Common.ValueObjects;
using ToDay_Shop.Orders.Core.Resources.Constants;
using ToDay_Shop.Orders.Core.Resources.Utilities.Guards;
using ToDay_Shop.Orders.Core.Resources.Utilities.Guards.GuardClauses;

namespace ToDay_Shop.Orders.Core.Domain.Orders.ValueObjects;
public sealed class Quantity : BaseValueObject<Quantity>
{
    public static Quantity FromInt(int value) => new(value);

    public Quantity(int value)
    {
        Guard.ThrowIf.GreaterThanOrEqual(value: value,
                                         minimumValue: 1,
                                         message: string.Format(ApplicationValidationError.VALIDATION_ERROR_MUST_GREATER_THAN_OR_EQUAL,
                                                                nameof(Quantity),
                                                                1));

        Value = value;
    }

    private Quantity()
    {
    }

    public int Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator int(Quantity quantity) => quantity.Value;
    public static implicit operator Quantity(int value) => new(value);
}