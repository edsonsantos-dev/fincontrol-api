using System.Linq.Expressions;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinControl.Data.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly FinControlContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(FinControlContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChangesAsync();
    }

    public virtual async Task<bool> RemoveAsync(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
        return await SaveChangesAsync() != 0;
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual Task<List<TEntity>> GetAllAsync(Guid accountId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}