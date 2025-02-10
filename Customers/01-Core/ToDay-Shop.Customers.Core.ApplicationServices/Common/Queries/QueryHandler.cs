using ToDay_Shop.Customers.Core.Contracts.Common.ApplicationServices.Queries;
using ToDay_Shop.Customers.Core.RequestResponse.Common;
using ToDay_Shop.Customers.Core.RequestResponse.Common.Queries;
using ToDay_Shop.Customers.Core.Resources.Utilities;

namespace ToDay_Shop.Customers.Core.ApplicationServices.Common.Queries;

public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    protected readonly QueryResult<TData> result = new();

    protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return Task.FromResult(result);
    }

    protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return result;
    }

    protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return ResultAsync(data, status);
    }

    protected virtual QueryResult<TData> Result(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return Result(data, status);
    }

    public QueryHandler()
    {
    }

    protected void AddMessage(string message)
    {
        result.AddMessage(message);
    }

    protected void AddMessage(string message, params string[] arguments)
    {
        result.AddMessage(StringPatternReplacementUtil.ReplaceArgs(message, arguments));
    }

    public abstract Task<QueryResult<TData>> Handle(TQuery query);
}