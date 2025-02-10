using ToDay_Shop.Customers.Core.RequestResponse.Common.Commands;

namespace ToDay_Shop.Customers.Core.Contracts.Common.ApplicationServices.Commands;

public interface ICommandDispatcher
{
    Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;
    Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;
}