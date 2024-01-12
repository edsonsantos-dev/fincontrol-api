using FinControl.Business.Models;
using FluentValidation;

namespace FinControl.Business.Interfaces;

public interface IGenericService<in TValidation, TEntity> : IDisposable
    where TValidation : AbstractValidator<TEntity>
    where TEntity : Entity
{
    Task<TEntity?> AddAsync(TEntity model);
    Task AddRangeAsync(IEnumerable<TEntity> models);
    Task<TEntity?> UpdateAsync(TEntity model);
    Task<bool> RunValidationAsync(TValidation validation, TEntity entity);
    Task<bool> RemoveAsync(Guid id);
}