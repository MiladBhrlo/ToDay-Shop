namespace ToDay_Shop.Orders.Endpoints.WebApp.Infrastructor.Middlewares.AppExceptionHandler;

public class ApiExceptionOptions
{
    public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }
    public Func<Exception, LogLevel> DetermineLogLevel { get; set; }
}
