namespace ToDay_Shop.Customers.Core.RequestResponse.Common.Commands;
public class CommandResult : ApplicationServiceResult
{
}

public class CommandResult<TData> : CommandResult
{
    public TData? _data;
    public TData? Data => _data;
}