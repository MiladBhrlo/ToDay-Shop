using ToDay_Shop.Orders.Core.Domain.Common.Entities;
using ToDay_Shop.Orders.Core.Domain.Common.Exceptions;
using ToDay_Shop.Orders.Core.Domain.Orders.Events;
using ToDay_Shop.Orders.Core.Domain.Orders.Parameters;
using ToDay_Shop.Orders.Core.Domain.Orders.ValueObjects;
using ToDay_Shop.Orders.Core.Resources.Constants;
using ToDay_Shop.Orders.Core.Resources.Utilities.Guards;
using ToDay_Shop.Orders.Core.Resources.Utilities.Guards.GuardClauses;
using static ToDay_Shop.Orders.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Orders.Core.Domain.Orders.Entities;
public sealed class Order : AggregateRoot
{
    #region Properties
    public long CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }

    public IReadOnlyList<OrderItem> Items => _items.ToList();
    private List<OrderItem> _items = new();
    #endregion

    #region Costructors
    private Order()
    {
    }
    private Order(CreateOrderParameter parameter)
    {
        CustomerId = parameter.CustomerId;
        Status = OrderStatus.Pending;

        AddEvent(new OrderCreated
        {
            OrderId=Id, // its better to use businessId insted of using id directly
            BusinessId = BusinessId.Value,
            CustomerId = CustomerId
        });

        foreach (CreateOrderItemParameter item in parameter.ItemParameters)
        {
            AddItem(item);
        }
    }
    #endregion

    #region Commands
    public static Order Create(CreateOrderParameter parameter) => new(parameter);

    private void UpdateStatus(OrderStatus status) => Status = status;

    public void Paid()
    {
        Guard.ThrowIf.Equal(Status,
                            OrderStatus.Pending,
                            ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA);
        UpdateStatus(OrderStatus.Paid);
        AddEvent(new OrderPaid { BusinessId = BusinessId.Value, });
    }

    public void Shipped()
    {
        Guard.ThrowIf.Equal(Status,
                            OrderStatus.Paid,
                            ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA);
        UpdateStatus(OrderStatus.Shipped);
        AddEvent(new OrderShipped { BusinessId = BusinessId.Value, });
    }

    public void AddItem(CreateOrderItemParameter orderItemParameter)
    {
        if (_items.Any(p => p.ProductId.Equals(orderItemParameter.ProductId)))
            throw new InvalidEntityStateException(ApplicationValidationError.VALIDATION_ERROR_ORDER_ITEM_EXIST);

        var orderItem = OrderItem.Create(orderItemParameter);
        _items.Add(orderItem);

        AddEvent(new OrderItemCreated
        {
            OrderBusinessId = BusinessId.Value,
            BusinessId = orderItem.BusinessId.Value,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity.Value,
        });
    }

    public void RemoveItem(long id)
    {
        var item = _items.FirstOrDefault(p => p.Id == id);
        Guard.ThrowIf.Null(item, ApplicationValidationError.VALIDATION_ERROR_ORDER_ITEM_NOT_EXIST);

        _items.Remove(item!);

        AddEvent(new OrderItemDeleted
        {
            BusinessId = item!.BusinessId.Value,
            OrderBusinessId = BusinessId.Value,
        });
    }

    public void UpdateItem(long orderItemId, Quantity quantity)
    {
        var item = _items.FirstOrDefault(p => p.Id == orderItemId);
        Guard.ThrowIf.Null(item, ApplicationValidationError.VALIDATION_ERROR_ORDER_ITEM_NOT_EXIST);
        item.Update(quantity);
        AddEvent(new OrderItemUpdated
        {
            BusinessId = item.BusinessId.Value,
            OrderBusinessId = BusinessId.Value,
            Quantity = quantity.Value,
        });
    }
    #endregion
}
