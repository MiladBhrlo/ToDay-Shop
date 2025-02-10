using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.ModelBinding;

public static class ModelBindingExtension
{
    public static IServiceCollection AddNonValidatingValidator(this IServiceCollection services)
    {
        var validator = services.FirstOrDefault(s => s.ServiceType == typeof(IObjectModelValidator));
        if (validator != null)
        {
            services.Remove(validator);
            services.Add(new ServiceDescriptor(typeof(IObjectModelValidator), _ => new NonValidatingValidator(), ServiceLifetime.Singleton));
        }
        return services;
    }
}
