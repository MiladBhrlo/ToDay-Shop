using ToDay_Shop.Customers.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Customers.Core.Contracts.Common.ApplicationServices.Queries;
public interface IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    Task<QueryResult<TData>> Handle(TQuery request);
}