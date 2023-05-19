﻿namespace SimpraOdev.Data.Repository.Base;

using SimpraOdev.Data.Context;
public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
{
    protected readonly SimpraDbContext dbContext;
    private bool disposed;

    public GenericRepository(SimpraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Delete(Entity entity)
    {
        dbContext.Set<Entity>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = dbContext.Set<Entity>().Find(id);
        dbContext.Set<Entity>().Remove(entity);
    }

    public List<Entity> GetAll()
    {
        return dbContext.Set<Entity>().ToList();
    }

    public Entity GetById(int id)
    {
        return dbContext.Set<Entity>().Find(id);
    }

    public void Insert(Entity entity)
    {
        entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);
        entity.GetType().GetProperty("CreatedBy").SetValue(entity, "simpra@simpra.com");

        dbContext.Set<Entity>().Add(entity);
    }

    public void Update(Entity entity)
    {
        dbContext.Set<Entity>().Update(entity);
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