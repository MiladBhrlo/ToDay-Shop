using ToDay_Shop.Payments.Core.Domain.Common.Entities;
using ToDay_Shop.Payments.Core.Domain.Payments.Events;
using ToDay_Shop.Payments.Core.Domain.Payments.Parameters;
using ToDay_Shop.Payments.Core.Domain.Payments.ValueObjects;
using ToDay_Shop.Payments.Core.Resources.Constants;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards;
using ToDay_Shop.Payments.Core.Resources.Utilities.Guards.GuardClauses;
using static ToDay_Shop.Payments.Core.Resources.Constants.ApplicationConsts;

namespace ToDay_Shop.Payments.Core.Domain.Payments.Entities;
public sealed class Payment : AggregateRoot
{
    #region Properties
    public long CustomerId { get; private set; }
    public long OrderId { get; private set; }
    public PaymentStatus Status { get; private set; }
    public PaymentMethod? Method { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public Price Price { get; private set; }
    public DateTime? PaymentSuccessDate { get; private set; }
    #endregion

    #region Costructors
    private Payment()
    {
    }
    private Payment(CreatePaymentParameter parameter)
    {
        CustomerId = parameter.CustomerId;
        OrderId = parameter.OrderId;
        Price = parameter.Price;
        Status = PaymentStatus.New;
        CreatedDate = DateTime.UtcNow;

        AddEvent(new PaymentCreated
        {
            PaymentId = Id, // its better to use businessId insted of using id directly
            BusinessId = BusinessId.Value,
            CustomerId = CustomerId,
            OrderId = OrderId,
            Price = Price.Value,
        });
    }
    #endregion

    #region Commands
    public static Payment Create(CreatePaymentParameter parameter) => new(parameter);

    private void UpdateStatus(PaymentStatus status) => Status = status;

    public void InProgress(PaymentMethod paymentMethod)
    {
        Method = paymentMethod;
        Guard.ThrowIf.Equal(Status,
                            PaymentStatus.New,
                            ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA);
        UpdateStatus(PaymentStatus.InProgress);
        AddEvent(new PaymentInProgressed { BusinessId = BusinessId.Value, });
    }

    public void Success()
    {
        Guard.ThrowIf.Equal(Status,
                            PaymentStatus.InProgress,
                            ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA);
        UpdateStatus(PaymentStatus.Success);
        PaymentSuccessDate = DateTime.UtcNow;
        AddEvent(new PaymentSuccessed { BusinessId = BusinessId.Value, });
    }

    public void Failed()
    {
        Guard.ThrowIf.Equal(Status,
                            PaymentStatus.InProgress,
                            ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA);
        UpdateStatus(PaymentStatus.Failed);
        AddEvent(new PaymentFailed { BusinessId = BusinessId.Value, });
    }

    public void Expired()
    {
        Guard.ThrowIf.NotEqual(Status,
                               PaymentStatus.Success,
                               ApplicationValidationError.VALIDATION_ERROR_INVALID_DATA);
        UpdateStatus(PaymentStatus.Expired);
        AddEvent(new PaymentExpired { BusinessId = BusinessId.Value, });
    }
    #endregion
}
