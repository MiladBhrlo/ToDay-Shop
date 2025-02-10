using Microsoft.AspNetCore.Mvc;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Commands.CreateCustomer;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.CommonResults;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.GetAll;
using ToDay_Shop.Customers.Endpoints.WebApp.Infrastructor;

namespace ToDay_Shop.Customers.Endpoints.WebApp.Features.Customers;

[Route("api/[controller]")]
public class CustomerController : BaseController
{
    #region Commands
    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        => await Create<CreateCustomerCommand, long>(command);

    #endregion

    #region Queries
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll(GetAllCustomersQuery query)
        => await Query<GetAllCustomersQuery, List<CustomerQr>>(query);
    #endregion
}
