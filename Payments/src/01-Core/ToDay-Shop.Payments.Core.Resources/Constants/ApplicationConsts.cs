using System.ComponentModel;

namespace ToDay_Shop.Payments.Core.Resources.Constants;
public static class ApplicationConsts
{
    #region ApplicationEventId
    public const int PerformanceMeasurement = 1001;
    public const int DomainValidationException = 1002;
    public const int CommandValidation = 1003;
    public const int QueryValidation = 1004;
    public const int EventValidation = 1005;
    #endregion

    #region Payment
    public enum PaymentStatus
    {
        [Description(ApplicationTranslationKey.NEW_PAYMENT)] New = 0,
        [Description(ApplicationTranslationKey.IN_PROGRESS_PAYMENT)] InProgress,
        [Description(ApplicationTranslationKey.SUCCESS_PAYMENT)] Success,
        [Description(ApplicationTranslationKey.FAILED_PAYMENT)] Failed,
        [Description(ApplicationTranslationKey.EXPIRED_PAYMENT)] Expired,
    }

    public enum PaymentMethod
    {
        [Description(ApplicationTranslationKey.CREDIT_CARD)] CreditCard = 0,
        [Description(ApplicationTranslationKey.CASH)] Cash,
        [Description(ApplicationTranslationKey.WALLET)] Wallet,
    }
    #endregion
}
