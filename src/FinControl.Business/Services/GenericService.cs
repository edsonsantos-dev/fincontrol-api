using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models.AuditableEntities;
using FinControl.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace FinControl.Business.Services;

public abstract class GenericService<TValidation, TEntity>(
    IRepository<TEntity> repository,
    INotifier _notifier)
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

        await NotifyAsync(validator);

        return false;
    }

    public virtual async Task<bool> RemoveAsync(Guid id)
    {
        return await repository.RemoveAsync(id);
    }

    protected Task NotifyAsync(string message)
    {
        _notifier.AddNotification(new Notification(message));
        
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