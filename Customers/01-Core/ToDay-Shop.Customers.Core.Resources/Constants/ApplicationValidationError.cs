namespace ToDay_Shop.Customers.Core.Resources.Constants;
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

    #endregion
}
