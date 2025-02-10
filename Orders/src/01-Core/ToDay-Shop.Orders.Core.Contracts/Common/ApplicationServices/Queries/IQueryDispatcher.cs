using ToDay_Shop.Orders.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Queries;
public interface IQueryDispatcher
{
    Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
}
