using System.ComponentModel;

namespace ToDay_Shop.Orders.Core.Resources.Constants;
public static class ApplicationConsts
{
    #region ApplicationEventId
    public const int PerformanceMeasurement = 1001;
    public const int DomainValidationException = 1002;
    public const int CommandValidation = 1003;
    public const int QueryValidation = 1004;
    public const int EventValidation = 1005;
    #endregion

    #region Order
    public enum OrderStatus
    {
        [Description(ApplicationTranslationKey.PENDING_ORDER)] Pending=0,
        [Description(ApplicationTranslationKey.PAID_ORDER)] Paid,
        [Description(ApplicationTranslationKey.SHIPPED_ORDER)] Shipped,
    }
    #endregion
}
