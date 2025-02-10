namespace ToDay_Shop.Orders.Core.RequestResponse.Common.Queries;
public sealed class QueryResult<TData> : ApplicationServiceResult
{
    public TData? _data;
    public TData? Data
    {
        get
        {
            return _data;
        }
    }
}