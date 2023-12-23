using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FluentValidation;

namespace FinControl.Business.Services;

public class GenericService<TValidation, TEntity>(
    IRepository repository)
    : IGenericService<TValidation, TEntity>
    where TValidation : AbstractValidator<TEntity>
    where TEntity : Entity
{
    public virtual async Task AddAsync(TEntity model)
    {
        await repository.AddAsync(model);
    }

    public virtual async Task UpdateAsync(TEntity model)
    {
        await repository.UpdateAsync(model);
    }

    public async Task<bool> RunValidationAsync(TValidation validation, TEntity entity)
    {
        var validator = await validation.ValidateAsync(entity);

        if (validator.IsValid) return true;

        //TODO: Throwing exceptions

        return false;
    }

    public virtual async Task<bool> RemoveAsync(Guid id)
    {
        return await repository.RemoveAsync(id);
    }

    public virtual void Dispose()
    {
        repository?.Dispose();
    }
}