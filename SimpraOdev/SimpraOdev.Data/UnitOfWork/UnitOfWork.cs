using SimpraOdev.Data.Context;
using SimpraOdev.Data.Models;
using SimpraOdev.Data.Repository.Base;

namespace SimApi.Data.Uow;

public class UnitOfWork : IUnitOfWork
{
    public IGenericRepository<Staff> StaffRepository { get; private set; }

    private readonly SimpraDbContext dbContext;
    private bool disposed;

    public UnitOfWork(SimpraDbContext dbContext)
    {
        this.dbContext = dbContext;


        StaffRepository = new GenericRepository<Staff>(dbContext);
    }
    public void Complete()
    {
        dbContext.SaveChanges();
    }

    public void CompleteWithTransaction()
    {
        using (var dbDcontextTransaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                dbDcontextTransaction.Commit();
            }
            catch (Exception ex)
            {
                // logging
                dbDcontextTransaction.Rollback();
            }
        }
    }


    private void Clean(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }

        disposed = true;
        GC.SuppressFinalize(this);
    }
    public void Dispose()
    {
        Clean(true);
    }
}