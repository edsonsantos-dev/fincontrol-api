using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace FinControl.Business.Services;

public abstract class GenericService<TValidation, TEntity>(
    IRepository<TEntity> repository,
    INotifier notifier)
    : IGenericService<TValidation, TEntity>
    where TValidation : AbstractValidator<TEntity>, new()
    where TEntity : Entity
{
    public virtual async Task<TEntity?> AddAsync(TEntity model)
    {
        if (!await RunValidationAsync(new TValidation(), model)) return null;
        
        await repository.AddAsync(model);

        return model;
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> models)
    {
        await repository.AddRangeAsync(models);
    }

    public virtual async Task<TEntity?> UpdateAsync(TEntity model)
    {
        if (!await RunValidationAsync(new TValidation(), model)) return null;
        
        await repository.UpdateAsync(model);

        return model;
    }

    public async Task<bool> RunValidationAsync(TValidation validation, TEntity entity)
    {
        var validator = await validation.ValidateAsync(entity);

        if (validator.IsValid) return true;

        await NotifyAsync(validator);

        return false;
    }

    public virtual async Task<bool> RemoveAsync(Guid id)
    {
        return await repository.RemoveAsync(id);
    }

    protected Task NotifyAsync(string message)
    {
        notifier.AddNotification(new Notification(message));
        
        return Task.CompletedTask;
    }

    private async Task NotifyAsync(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors)
        {
            await NotifyAsync(item.ErrorMessage);
        }
    }

    public virtual void Dispose()
    {
        repository?.Dispose();
    }
}