using ToDay_Shop.Payments.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Queries;
public interface IQueryDispatcher
{
    Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
}
