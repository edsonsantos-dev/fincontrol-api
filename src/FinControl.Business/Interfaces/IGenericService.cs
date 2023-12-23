using FinControl.Business.Models;

namespace FinControl.Business.Interfaces;

public interface IGenericService<TEntity> : IDisposable where TEntity : Entity
{
    Task AddAsync(TEntity model);
    Task UpdateAsync(TEntity model);
    Task<bool> RemoveAsync(Guid id);
}