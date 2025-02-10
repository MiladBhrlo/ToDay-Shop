using ToDay_Shop.Payments.Core.Contracts.Common.Data.Queries;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Queries.Common;

public class BaseQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}