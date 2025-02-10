using System.Data.Common;
using FluentValidation.AspNetCore;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Middlewares.AppExceptionHandler;

namespace ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.DependencyInjection;


public static class AddApiConfigurationExtensions
{
    public static IServiceCollection AddApplicationApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
    {
        services.AddControllers().AddFluentValidation();
        services.AddApplicationDependencies(assemblyNamesForLoad);

        return services;
    }

    public static void UseApplicationApiExceptionHandler(this IApplicationBuilder app)
    {

        app.UseApiExceptionHandler(options =>
        {
            options.AddResponseDetails = (context, ex, error) =>
            {
                if (ex.GetType().Name == typeof(DbException).Name)
                {
                    error.Detail = "Exception was a database exception!";
                }
            };
            options.DetermineLogLevel = ex =>
            {
                if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                    ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                {
                    return LogLevel.Critical;
                }
                return LogLevel.Error;
            };
        });

    }
}