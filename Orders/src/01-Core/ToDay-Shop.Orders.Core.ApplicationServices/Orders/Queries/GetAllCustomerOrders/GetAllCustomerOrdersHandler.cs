using ToDay_Shop.Orders.Core.ApplicationServices.Common.Queries;
using ToDay_Shop.Orders.Core.Contracts.Orders.Queries;
using ToDay_Shop.Orders.Core.RequestResponse.Common.Queries;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Queries.GetAllCustomerOrders;

namespace ToDay_Shop.Orders.Core.ApplicationServices.Orders.Queries.GetAllCustomerOrders;
public sealed class GetAllCustomerOrdersHandler : QueryHandler<GetAllCustomerOrdersQuery, List<OrderSelectItemQr>>
{
    private readonly IOrderQueryRepository _orderQueryRepository;

    public GetAllCustomerOrdersHandler(IOrderQueryRepository orderQueryRepository)
    {
        _orderQueryRepository = orderQueryRepository;
    }

    public override async Task<QueryResult<List<OrderSelectItemQr>>> Handle(GetAllCustomerOrdersQuery query)
        => Result(await _orderQueryRepository.ExecuteAsync(query));
}