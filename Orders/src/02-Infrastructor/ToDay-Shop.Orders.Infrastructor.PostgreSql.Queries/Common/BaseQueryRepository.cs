using ToDay_Shop.Orders.Core.Contracts.Common.Data.Queries;

namespace ToDay_Shop.Orders.Infrastructor.PostgreSql.Queries.Common;

public class BaseQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}