﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.DependencyInjection;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.IdentityServer.Extentions;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.MassTransit;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions.Swaggers.Extentions;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.ModelBinding;
using ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Common;
using ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Common.Interceptors;
using ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Common;

namespace ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor.Extensions;


public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddEnvironmentVariables();

        IConfiguration configuration = builder.Configuration;

        builder.Services.AddLogging(builder => builder.AddConsole());

        builder.Services.AddApplicationApiCore("ToDay-Shop", "ToDay-Shop.Customers");

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddNonValidatingValidator();

        //CommandDbContext
        builder.Services.AddDbContext<CustomersCommandDbContext>(
            c => c.UseNpgsql(configuration.GetConnectionString("CommandDb_ConnectionString"))
            .AddInterceptors(new SetPersianYeKeInterceptor(),
                             new AddAuditDataInterceptor()));

        //QueryDbContext
        builder.Services.AddDbContext<CustomersQueryDbContext>(
            c => c.UseNpgsql(configuration.GetConnectionString("QueryDb_ConnectionString")));

        builder.Services.AddApplicationMessaging(configuration, "RabbitMQ");

        builder.Services.AddIdentityServer(configuration, "OAuth");

        builder.Services.AddSwagger(configuration, "Swagger");

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseApplicationApiExceptionHandler();

        app.UseSwaggerUI("Swagger");

        app.UseStatusCodePages();

        app.UseCors(delegate (CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

        app.UseHttpsRedirection();

        var useIdentityServer = app.UseIdentityServer("OAuth");

        var controllerBuilder = app.MapControllers();

        if (useIdentityServer)
            controllerBuilder.RequireAuthorization();

        return app;
    }
}