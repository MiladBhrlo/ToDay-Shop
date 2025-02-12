﻿using ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Commands;
using ToDay_Shop.Payments.Core.RequestResponse.Common;
using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Common.Commands;

public abstract class CommandHandler<TCommand, TData> : ICommandHandler<TCommand, TData>
    where TCommand : ICommand<TData>
{

    protected readonly CommandResult<TData> result = new();
    public CommandHandler()
    {
    }

    public abstract Task<CommandResult<TData>> Handle(TCommand command);
    protected virtual Task<CommandResult<TData>> OkAsync(TData data)
    {
        result._data = data;
        result.Status = ApplicationServiceStatus.Ok;
        return Task.FromResult(result);
    }
    protected virtual CommandResult<TData> Ok(TData data)
    {
        result._data = data;
        result.Status = ApplicationServiceStatus.Ok;
        return result;
    }
    protected virtual Task<CommandResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return Task.FromResult(result);
    }

    protected virtual CommandResult<TData> Result(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return result;
    }

    protected void AddMessage(string message)
    {
        result.AddMessage(message);
    }
    protected void AddMessage(string message, params string[] arguments)
    {
        result.AddMessage(string.Format(message, arguments));
    }
}

public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
where TCommand : ICommand
{
    protected readonly CommandResult result = new();
    public CommandHandler()
    {
    }
    public abstract Task<CommandResult> Handle(TCommand command);

    protected virtual Task<CommandResult> OkAsync()
    {
        result.Status = ApplicationServiceStatus.Ok;
        return Task.FromResult(result);
    }

    protected virtual CommandResult Ok()
    {
        result.Status = ApplicationServiceStatus.Ok;
        return result;
    }

    protected virtual Task<CommandResult> ResultAsync(ApplicationServiceStatus status)
    {
        result.Status = status;
        return Task.FromResult(result);
    }
    protected virtual CommandResult Result(ApplicationServiceStatus status)
    {
        result.Status = status;
        return result;
    }
    protected void AddMessage(string message)
    {
        result.AddMessage(message);
    }
    protected void AddMessage(string message, params string[] arguments)
    {
        result.AddMessage(string.Format(message, arguments));
    }
}