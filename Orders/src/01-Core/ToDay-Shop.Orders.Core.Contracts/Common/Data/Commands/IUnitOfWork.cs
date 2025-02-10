namespace ToDay_Shop.Orders.Core.Contracts.Common.Data.Commands;

public interface IUnitOfWork
{
    void BeginTransaction();

    void CommitTransaction();

    void RollbackTransaction();

    int Commit();

    Task<int> CommitAsync();
}