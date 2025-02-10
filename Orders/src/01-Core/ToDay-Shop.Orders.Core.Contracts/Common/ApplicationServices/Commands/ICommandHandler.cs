using ToDay_Shop.Orders.Core.RequestResponse.Common.Commands;

namespace ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Commands;
public interface ICommandHandler<TCommand, TData> where TCommand : ICommand<TData>
{
    Task<CommandResult<TData>> Handle(TCommand request);
}

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task<CommandResult> Handle(TCommand request);
}