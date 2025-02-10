using ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Queries;
using ToDay_Shop.Orders.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Orders.Core.ApplicationServices.Common.Queries;

public abstract class QueryDispatcherDecorator : IQueryDispatcher
{
    #region Fields
    protected IQueryDispatcher _queryDispatcher;
    public abstract int Order { get; }
    #endregion

    #region Constructors
    public QueryDispatcherDecorator() { }
    #endregion

    #region Query Dispatcher
    public abstract Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
    #endregion

    #region Methods
    public void SetQueryDispatcher(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }
    #endregion
}