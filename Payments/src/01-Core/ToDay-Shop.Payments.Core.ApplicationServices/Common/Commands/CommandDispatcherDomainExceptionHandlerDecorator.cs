using Microsoft.Extensions.Logging;
using ToDay_Shop.Payments.Core.Domain.Common.Exceptions;
using ToDay_Shop.Payments.Core.RequestResponse.Common;
using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Payments.Core.Resources.Constants;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Common.Commands;

public class CommandDispatcherDomainExceptionHandlerDecorator : CommandDispatcherDecorator
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CommandDispatcherDomainExceptionHandlerDecorator> _logger;
    #endregion

    #region Constructors
    public CommandDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider,
                                                            ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public override int Order => 2;
    #endregion

    #region Send Commands
    public override async Task<CommandResult> Send<TCommand>(TCommand command)
    {
        try
        {
            var result = _commandDispatcher.Send(command);
            return await result;
        }
        catch (DomainStateException ex)
        {
            _logger.LogError(ApplicationConsts.DomainValidationException,
                             ex,
                             "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.",
                             command.GetType(),
                             command,
                             DateTime.Now);
            return DomainExceptionHandlingWithoutReturnValue<TCommand>(ex);
        }
        catch (AggregateException ex)
        {
            if (ex.InnerException is DomainStateException domainStateException)
            {
                _logger.LogError(ApplicationConsts.DomainValidationException,
                                 domainStateException,
                                 "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.",
                                 command.GetType(),
                                 command,
                                 DateTime.Now);
                return DomainExceptionHandlingWithoutReturnValue<TCommand>(domainStateException);
            }
            throw ex;
        }

    }

    public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
    {
        try
        {
            var result = await _commandDispatcher.Send<TCommand, TData>(command);
            return result;

        }
        catch (DomainStateException ex)
        {
            _logger.LogError(ApplicationConsts.DomainValidationException,
                             ex,
                             "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.",
                             command.GetType(),
                             command,
                             DateTime.Now);
            return DomainExceptionHandlingWithReturnValue<TCommand, TData>(ex);
        }
        catch (AggregateException ex)
        {
            if (ex.InnerException is DomainStateException domainStateException)
            {
                _logger.LogError(ApplicationConsts.DomainValidationException,
                                 ex,
                                 "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.",
                                 command.GetType(),
                                 command,
                                 DateTime.Now);
                return DomainExceptionHandlingWithReturnValue<TCommand, TData>(domainStateException);
            }
            throw ex;
        }
    }
    #endregion

    #region Privaite Methods
    private CommandResult DomainExceptionHandlingWithoutReturnValue<TCommand>(DomainStateException ex)
    {
        var commandResult = new CommandResult
        {
            Status = ApplicationServiceStatus.InvalidDomainState
        };

        commandResult.AddMessage(GetExceptionText(ex));

        return commandResult;
    }

    private CommandResult<TData> DomainExceptionHandlingWithReturnValue<TCommand, TData>(DomainStateException ex)
    {
        var commandResult = new CommandResult<TData>()
        {
            Status = ApplicationServiceStatus.InvalidDomainState
        };

        commandResult.AddMessage(GetExceptionText(ex));

        return commandResult;
    }

    private string GetExceptionText(DomainStateException domainStateException)
    {
        // can use translator service to translate exception message
        _logger.LogInformation(ApplicationConsts.DomainValidationException,
                               "Domain Exception message is {DomainExceptionMessage}",
                               domainStateException);

        return domainStateException.ToString();

    }
    #endregion
}