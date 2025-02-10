using ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Common;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Customers;
public sealed class Customer: QueryObject
{
    public string FirstName { get; set; }=string.Empty;
    public string LastName { get; set; }=string.Empty;
}
