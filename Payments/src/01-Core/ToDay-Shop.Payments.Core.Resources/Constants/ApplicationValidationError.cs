namespace ToDay_Shop.Payments.Core.Resources.Constants;
public static class ApplicationValidationError
{
    #region Common
    /// <summary>
    /// مقدار {0} اجباری می باشد
    /// </summary>
    public const string VALIDATION_ERROR_REQUIRED = nameof(VALIDATION_ERROR_REQUIRED);

    /// <summary>
    /// مقدار {0} نامعتبر است
    /// </summary>
    public const string VALIDATION_ERROR_INVALID_DATA = nameof(VALIDATION_ERROR_INVALID_DATA);

    #region String
    /// <summary>
    /// تعداد کاراکتر مجاز برای {0} باید بین {1} و {2} باشد
    /// </summary>
    public const string VALIDATION_ERROR_INVALID_STRING_LENGTH_BETWEEN = nameof(VALIDATION_ERROR_INVALID_STRING_LENGTH_BETWEEN);

    /// <summary>
    /// 
    /// </summary>
    public const string VALIDATION_ERROR_INVALID_STRING_MIN_LENGTH = nameof(VALIDATION_ERROR_INVALID_STRING_MIN_LENGTH);

    /// <summary>
    /// 
    /// </summary>
    public const string VALIDATION_ERROR_INVALID_STRING_MAX_LENGTH = nameof(VALIDATION_ERROR_INVALID_STRING_MAX_LENGTH);
    #endregion

    #region Number
    /// <summary>
    /// مقدار {0} باید بزرگتر یا برابر با {1} باشد
    /// </summary>
    public const string VALIDATION_ERROR_MUST_GREATER_THAN_OR_EQUAL = nameof(VALIDATION_ERROR_MUST_GREATER_THAN_OR_EQUAL);

    /// <summary>
    /// مقدار {0} باید بزرگتر از {1} باشد
    /// </summary>
    public const string VALIDATION_ERROR_MUST_GREATER_THAN = nameof(VALIDATION_ERROR_MUST_GREATER_THAN);
    #endregion
    #endregion

    #region Order
    /// <summary>
    /// محصول مورد نظر در سفارش وجود دارد
    /// </summary>
    public const string VALIDATION_ERROR_ORDER_ITEM_EXIST = nameof(VALIDATION_ERROR_ORDER_ITEM_EXIST);

    /// <summary>
    /// محصول مورد نظر در سفارش وجود ندارد
    /// </summary>
    public const string VALIDATION_ERROR_ORDER_ITEM_NOT_EXIST = nameof(VALIDATION_ERROR_ORDER_ITEM_NOT_EXIST);
    #endregion
}
