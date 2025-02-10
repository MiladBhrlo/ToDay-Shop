using ToDay_Shop.Orders.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Orders.Core.Contracts.Common.ApplicationServices.Queries;
public interface IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    Task<QueryResult<TData>> Handle(TQuery request);
}