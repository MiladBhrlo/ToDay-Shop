using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.Extensions.Swaggers.Extentions;
using ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.Extensions.Swaggers.Filters;
using ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.Extensions.Swaggers.Options;

namespace ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.Extensions.Swaggers.Extentions;

public static class SwaggerExtentions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        var swaggerOption = configuration.GetSection(sectionName).Get<SwaggerOption>();

        if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enabled == true)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc(swaggerOption.SwaggerDoc.Name, new OpenApiInfo
                {
                    Title = swaggerOption.SwaggerDoc.Title,
                    Version = swaggerOption.SwaggerDoc.Version
                });

                var oAuthOption = swaggerOption.OAuth;
                if (oAuthOption != null && oAuthOption.Enabled)
                {
                    o.AddSecurityDefinition("Oauth2", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Description = "Oauth2",
                        BearerFormat = "Bearer <token>",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            AuthorizationCode = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri(oAuthOption.AuthorizationUrl),
                                TokenUrl = new Uri(oAuthOption.TokenUrl),
                                Scopes = oAuthOption.Scopes
                            }
                        },
                    }); ;

                    o.OperationFilter<AddParamsToHeader>();
                }
            });
        }

        return services;
    }

    public static void UseSwaggerUI(this WebApplication app, string sectionName)
    {
        var swaggerOption = app.Configuration.GetSection(sectionName).Get<SwaggerOption>();

        if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enabled == true)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.DocExpansion(DocExpansion.None);
                option.SwaggerEndpoint(swaggerOption.SwaggerDoc.URL, swaggerOption.SwaggerDoc.Title);
                option.RoutePrefix = "swagger";
                option.OAuthClientId(swaggerOption.OAuth.ClientId);
                option.OAuthUsePkce();
            });
        }
    }
}
