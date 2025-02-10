namespace ToDay_Shop.Customers.Core.Contracts.Common.Data.Commands;

public interface IUnitOfWork
{
    void BeginTransaction();

    void CommitTransaction();

    void RollbackTransaction();

    int Commit();

    Task<int> CommitAsync();
}