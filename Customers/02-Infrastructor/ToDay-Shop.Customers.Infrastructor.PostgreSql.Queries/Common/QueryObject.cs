namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Queries.Common;
public class QueryObject
{
    public long Id { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public Guid BusinessId { get; set; }
}
