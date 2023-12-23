using System.Linq.Expressions;
using FinControl.Business.Models;

namespace FinControl.Business.Interfaces.Repositories;

public interface IRepository : IDisposable
{
    Task AddAsync<TEntity>(TEntity entity);
    Task UpdateAsync<TEntity>(TEntity entity);
    Task<bool> RemoveAsync(Guid id);
    Task<TEntity> GetByIdAsync<TEntity>(Guid id);
    Task<List<TEntity>> GetAllAsync<TEntity>(Guid accountId);
    Task<IEnumerable<TEntity>> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChangesAsync();
}