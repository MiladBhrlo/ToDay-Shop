using FluentValidation;
using MassTransit;
using MediatR;
using System.Reflection;
using ToDay_Shop.Customers.Core.ApplicationServices.Common.Events;
using ToDay_Shop.Customers.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.MassTransit.Options;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.Messaging.MediatoRPipelineBehaviors;

namespace ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.MassTransit;

public static class MessagingExtensions
{
    public static IServiceCollection AddApplicationMessaging(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IEventDispatcher, EventDispatcher>();

        var massTransitOption = configuration.GetSection(sectionName).Get<MassTransitOption>();

        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.GetExecutingAssembly());
            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(prefix: "shop", includeNamespace: false));

            x.UsingRabbitMq((context, config) =>
            {
                var settings = configuration.GetSection("RabbitMQ").Get<MassTransitOption>();

                config.Host(settings.Host, h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                config.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("shop", false));

                config.UseMessageRetry(r => r.Interval(3, 1000));
            });
        });
        return services;
    }
}
