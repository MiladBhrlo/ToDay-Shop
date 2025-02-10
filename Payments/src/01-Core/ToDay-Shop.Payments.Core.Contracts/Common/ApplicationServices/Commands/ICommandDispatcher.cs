using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;

namespace ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Commands;

public interface ICommandDispatcher
{
    Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;
    Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;
}