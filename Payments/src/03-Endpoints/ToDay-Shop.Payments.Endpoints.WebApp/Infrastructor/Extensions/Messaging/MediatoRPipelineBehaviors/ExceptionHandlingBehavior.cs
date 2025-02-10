using MediatR;
using ToDay_Shop.Payments.Core.Domain.Common.Events;
using ToDay_Shop.Payments.Core.Domain.Common.Exceptions;

namespace ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.Extensions.Messaging.MediatoRPipelineBehaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IDomainEvent
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (DomainStateException ex)
        {
            _logger.LogError(ex,
                             "Domain exception occurred while processing {RequestType}",
                             typeof(TRequest).Name);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                             "An unexpected error occurred while processing {RequestType}",
                             typeof(TRequest).Name);
            throw;
        }
    }
}