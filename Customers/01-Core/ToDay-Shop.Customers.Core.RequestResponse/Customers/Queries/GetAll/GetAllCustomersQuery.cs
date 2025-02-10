using ToDay_Shop.Customers.Core.RequestResponse.Common;
using ToDay_Shop.Customers.Core.RequestResponse.Common.Queries;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.CommonResults;

namespace ToDay_Shop.Customers.Core.RequestResponse.Customers.Queries.GetAll;

public sealed class GetAllCustomersQuery : IQuery<List<CustomerQr>>, IWebRequest
{
    public string Path => "/Api/Customer/GetAll";
}
