﻿namespace ToDay_Shop.Customers.Core.Resources.Constants;
public static class ApplicationConsts
{
    #region ApplicationEventId
    public const int PerformanceMeasurement = 1001;
    public const int DomainValidationException = 1002;
    public const int CommandValidation = 1003;
    public const int QueryValidation = 1004;
    public const int EventValidation = 1005;
    #endregion

    #region Customer
    public const byte NameMinLength = 2;
    public const int NameMaxLength = 25;

    #endregion
}
