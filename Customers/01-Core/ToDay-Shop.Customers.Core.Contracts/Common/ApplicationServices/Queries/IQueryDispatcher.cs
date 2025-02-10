using ToDay_Shop.Customers.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Customers.Core.Contracts.Common.ApplicationServices.Queries;
public interface IQueryDispatcher
{
    Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
}
