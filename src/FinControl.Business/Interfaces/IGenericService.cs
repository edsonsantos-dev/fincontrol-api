using FinControl.Business.Models;

namespace FinControl.Business.Interfaces;

public interface IGenericService<T> : IDisposable where T : Entity
{
    Task<T> AddAsync(T model);
    Task<T> UpdateAsync(T model);
    Task<bool> RemoveAsync(Guid id);
}