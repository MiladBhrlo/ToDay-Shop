using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.ModelBinding;

public sealed class NonValidatingValidator : IObjectModelValidator
{
    public void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)
    {
        foreach (var entry in actionContext.ModelState.Values)
            entry.ValidationState = ModelValidationState.Skipped;

    }
}