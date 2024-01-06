using FinControl.Business.Models;
using FluentValidation;

namespace FinControl.Business.Interfaces;

public interface IGenericService<in TValidation, in TEntity> : IDisposable
    where TValidation : AbstractValidator<TEntity>
    where TEntity : Entity
{
    Task AddAsync(TEntity model);
    Task AddRangeAsync(IEnumerable<TEntity> models);
    Task UpdateAsync(TEntity model);
    Task<bool> RunValidationAsync(TValidation validation, TEntity entity);
    Task<bool> RemoveAsync(Guid id);
}