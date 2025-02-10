using ToDay_Shop.Customers.Core.ApplicationServices.Common.Queries;
using ToDay_Shop.Customers.Core.Contracts.Customers.Queries;
using ToDay_Shop.Customers.Core.RequestResponse.Common.Queries;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.CommonResults;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.GetAll;

namespace ToDay_Shop.Customers.Core.ApplicationServices.Customers.Queries.GetAll;

public sealed class GetAllCustomersHandler : QueryHandler<GetAllCustomersQuery, List<CustomerQr>>
{
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public GetAllCustomersHandler(ICustomerQueryRepository customerQueryRepository)
    {
        _customerQueryRepository = customerQueryRepository;
    }

    public override async Task<QueryResult<List<CustomerQr>>> Handle(GetAllCustomersQuery query)
        => Result(await _customerQueryRepository.ExecuteAsync(query));
}
