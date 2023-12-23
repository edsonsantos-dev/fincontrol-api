using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FluentValidation;

namespace FinControl.Business.Interfaces;

public interface IGenericService<in TValidation, in TEntity> : IDisposable
    where TValidation : AbstractValidator<TEntity>
    where TEntity : Entity
{
    Task AddAsync(TEntity model);
    Task UpdateAsync(TEntity model);
    Task<bool> RunValidationAsync(TValidation validation, TEntity entity);
    Task<bool> RemoveAsync(Guid id);
}