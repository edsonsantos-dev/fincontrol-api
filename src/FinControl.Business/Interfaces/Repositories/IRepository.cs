using System.Linq.Expressions;
using FinControl.Business.Models;

namespace FinControl.Business.Interfaces.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity 
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task<bool> RemoveAsync(Guid id);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<List<TEntity>> GetAllAsync(Guid accountId);
    Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChangesAsync();
}