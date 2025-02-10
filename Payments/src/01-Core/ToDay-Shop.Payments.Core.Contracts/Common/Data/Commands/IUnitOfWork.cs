namespace ToDay_Shop.Payments.Core.Contracts.Common.Data.Commands;

public interface IUnitOfWork
{
    void BeginTransaction();

    void CommitTransaction();

    void RollbackTransaction();

    int Commit();

    Task<int> CommitAsync();
}