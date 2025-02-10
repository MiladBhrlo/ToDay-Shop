using Microsoft.AspNetCore.Mvc;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Commands.Create;
using ToDay_Shop.Orders.Core.RequestResponse.Orders.Queries.GetAllCustomerOrders;
using ToDay_Shop.Orders.Endpoints.WebApp.Infrastructor;

namespace ToDay_Shop.Orders.Endpoints.WebApp.Features.Orders;

[Route("api/[controller]")]
public class OrderController : BaseController
{
    #region Commands
    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        => await Create<CreateOrderCommand, long>(command);

    #endregion

    #region Queries
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll(GetAllCustomerOrdersQuery query)
        => await Query<GetAllCustomerOrdersQuery, List<OrderSelectItemQr>>(query);
    #endregion
}
