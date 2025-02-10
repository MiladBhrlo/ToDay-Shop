using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDay_Shop.Payments.Core.Contracts.Common.Data.Commands;
using ToDay_Shop.Payments.Core.Domain.Common.Entities;
using ToDay_Shop.Payments.Core.Domain.Common.ValueObjects;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common;
public class BaseCommandRepository<TEntity, TDbContext> : ICommandRepository<TEntity>, IUnitOfWork
    where TEntity : AggregateRoot
    where TDbContext : BaseCommandDbContext
{

    protected readonly TDbContext _dbContext;

    public BaseCommandRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }



    public void Delete(long id)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void DeleteGraph(long id)
    {
        var entity = GetGraph(id);
        if (entity is not null && !entity.Id.Equals(default))
            _dbContext.Set<TEntity>().Remove(entity);
    }





    #region insert

    public void Insert(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }
    #endregion

    #region Get Single Item
    public TEntity Get(long id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public TEntity Get(BusinessId businessId)
    {
        return _dbContext.Set<TEntity>().FirstOrDefault(c => c.BusinessId == businessId);
    }

    public async Task<TEntity> GetAsync(long id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> GetAsync(BusinessId businessId)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(c => c.BusinessId == businessId);
    }
    #endregion

    #region Get single item with graph
    public TEntity GetGraph(long id)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        var temp = graphPath.ToList();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return query.FirstOrDefault(c => c.Id.Equals(id));
    }

    public TEntity GetGraph(BusinessId businessId)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        var temp = graphPath.ToList();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return query.FirstOrDefault(c => c.BusinessId == businessId);
    }

    public async Task<TEntity> GetGraphAsync(long id)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return await query.FirstOrDefaultAsync(c => c.Id.Equals(id));
    }

    public async Task<TEntity> GetGraphAsync(BusinessId businessId)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return await query.FirstOrDefaultAsync(c => c.BusinessId == businessId);
    }
    #endregion

    #region Exists
    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().Any(expression);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbContext.Set<TEntity>().AnyAsync(expression);
    }
    #endregion

    #region Transaction management
    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public Task<int> CommitAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
    public void BeginTransaction()
    {
        _dbContext.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _dbContext.CommitTransaction();
    }
    public void RollbackTransaction()
    {
        _dbContext.RollbackTransaction();
    }
    #endregion
}