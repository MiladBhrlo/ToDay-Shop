using ToDay_Shop.Customers.Core.RequestResponse.Common;
using ToDay_Shop.Customers.Core.RequestResponse.Common.Commands;

namespace ToDay_Shop.Customers.Core.RequestResponse.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommand : ICommand<long>, IWebRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Path => "/Api/Customer/Create";
}
