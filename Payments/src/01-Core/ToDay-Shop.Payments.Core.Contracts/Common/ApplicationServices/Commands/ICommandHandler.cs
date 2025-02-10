using ToDay_Shop.Payments.Core.RequestResponse.Common.Commands;

namespace ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Commands;
public interface ICommandHandler<TCommand, TData> where TCommand : ICommand<TData>
{
    Task<CommandResult<TData>> Handle(TCommand request);
}

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task<CommandResult> Handle(TCommand request);
}