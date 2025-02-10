using FluentValidation;
using MassTransit;
using MediatR;
using System.Reflection;
using ToDay_Shop.Orders.Core.ApplicationServices.Common.Events;
using ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Orders.Endpoints.WebApp.Infrastructor.Extensions.Messaging.MediatoRPipelineBehaviors;
using ToDay_Shop.Orders.Endpoints.WebApp.Infrastructor.Extensions.Messaging.Options;

namespace ToDay_Shop.Orders.Endpoints.WebApp.Infrastructor.Extensions.Messaging;

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
