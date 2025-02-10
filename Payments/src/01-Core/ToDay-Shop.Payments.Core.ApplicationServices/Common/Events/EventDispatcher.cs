using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Events;
using ToDay_Shop.Payments.Core.Domain.Common.Events;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Common.Events;

public class EventDispatcher : IEventDispatcher
{
    #region Fields
    private readonly IMediator _mediator;
    private readonly ILogger<EventDispatcher> _logger;
    private readonly Stopwatch _stopwatch;
    #endregion

    #region Constructors
    public EventDispatcher(IMediator mediator, ILogger<EventDispatcher> logger)
    {
        _mediator = mediator;
        _logger = logger;
        _stopwatch = new Stopwatch();
    }
    #endregion

    #region Event Dispatcher
    public async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent, INotification
    {
        _stopwatch.Start();

        try
        {
            _logger.LogDebug("Routing event of type {EventType} With value {Event}  Start at {StartDateTime}",
                             @event.GetType(),
                             @event,
                             DateTime.Now);

            await _mediator.Publish(@event);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex,
                             "There is not suitable handler for {EventType} Routing failed at {StartDateTime}.",
                             @event.GetType(),
                             DateTime.Now);
            throw;
        }
        finally
        {
            _stopwatch.Stop();
            _logger.LogDebug("Dispatch event {EventType} ,EventHandlers tooks {Millisecconds} Millisecconds",
                             @event.GetType(),
                             _stopwatch.ElapsedMilliseconds);
        }
    }
    #endregion
}