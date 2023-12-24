using System.Linq.Expressions;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class CategoryService(
    IRepository<Category> repository,
    INotifier notifier) :
    GenericService<CategoryValidation, Category>(repository, notifier)
{
    public override async Task AddAsync(Category model)
    {
        if (!await RunValidationAsync(new CategoryValidation(), model)) return;


        if (await CategoryExists(x => x.Name == model.Name))
        {
            await NotifyAsync("Já há uma categoria registrada com esse nome.");
            return;
        }

        await base.AddAsync(model);
    }

    public override async Task UpdateAsync(Category model)
    {
        if (!await RunValidationAsync(new CategoryValidation(), model)) return;

        if (await CategoryExists(x => x.Name == model.Name && x.Id != model.Id))
        {
            await NotifyAsync("Já há uma categoria registrada com esse nome.");
            return;
        }

        await base.UpdateAsync(model);
    }

    public override async Task<bool> RemoveAsync(Guid id)
    {
        var category = await repository.GetByIdAsync(id);

        if (category.Transactions.Count == 0) return await base.RemoveAsync(id);

        await NotifyAsync("Não é possível remover uma categoria que possui transações.");
        return false;
    }

    private async Task<bool> CategoryExists(Expression<Func<Category, bool>> predicate)
    {
        var categories = await repository.SearchAsync(predicate);

        return categories.Any();
    }
}