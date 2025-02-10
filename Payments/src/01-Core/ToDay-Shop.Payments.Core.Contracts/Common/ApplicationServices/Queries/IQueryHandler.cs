using ToDay_Shop.Payments.Core.RequestResponse.Common.Queries;

namespace ToDay_Shop.Payments.Core.Contracts.Common.ApplicationServices.Queries;
public interface IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    Task<QueryResult<TData>> Handle(TQuery request);
}