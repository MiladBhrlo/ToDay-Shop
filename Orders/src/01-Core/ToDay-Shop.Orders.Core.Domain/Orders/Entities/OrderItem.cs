using ToDay_Shop.Orders.Core.Domain.Common.Entities;
using ToDay_Shop.Orders.Core.Domain.Orders.Parameters;
using ToDay_Shop.Orders.Core.Domain.Orders.ValueObjects;

namespace ToDay_Shop.Orders.Core.Domain.Orders.Entities;

public sealed class OrderItem : Entity
{
    #region Properties
    public long OrderId { get; private set; }
    public long ProductId { get; private set; }
    public Quantity Quantity { get; private set; }
    #endregion

    #region Constructors
    private OrderItem()
    {
    }

    private OrderItem(CreateOrderItemParameter parameter)
    {
        ProductId = parameter.ProductId;
        Quantity = parameter.Quantity;
    }
    #endregion

    #region Commands
    public static OrderItem Create(CreateOrderItemParameter parameter) => new(parameter);

    public void Update(Quantity quantity) => Quantity = quantity;
    #endregion
}
