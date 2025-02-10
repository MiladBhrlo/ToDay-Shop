using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Commands;
using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Queries;

namespace ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.Extensions;


public static class HttpContextExtensions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));

    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));
}