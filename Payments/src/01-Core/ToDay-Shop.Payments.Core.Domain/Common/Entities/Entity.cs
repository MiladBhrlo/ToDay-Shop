using ToDay_Shop.Payments.Core.Domain.Common.ValueObjects;

namespace ToDay_Shop.Payments.Core.Domain.Common.Entities;

public abstract class Entity : IAuditableEntity
{
    public long Id { get; protected set; }

    public BusinessId BusinessId { get; protected set; } = BusinessId.FromGuid(Guid.NewGuid());

    protected Entity() { }

    #region Equality Check
    public bool Equals(Entity? other) => this == other;
    public override bool Equals(object? obj) =>
         obj is Entity otherObject && Id.Equals(otherObject.Id);

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity left, Entity right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;
        return left.Equals(right);
    }
    public static bool operator !=(Entity left, Entity right)
        => !(right == left);

    #endregion
}
