using System.Linq.Expressions;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class CategoryService(
    IRepository<Category> repository,
    INotifier notifier,
    IUserContext userContext) :
    GenericService<CategoryValidation, Category>(repository, notifier)
{
    public override async Task<Category?> AddAsync(Category model)
    {
        if (!await CategoryExists(x => x.Name == model.Name &&
                                       x.AccountId == userContext.GetAccountId()))
        {
            return await base.AddAsync(model);
        }

        await NotifyAsync("Já há uma categoria registrada com esse nome.");
        return null;
    }

    public override async Task<Category?> UpdateAsync(Category? model)
    {
        if (!await CategoryExists(x => x.Name == model.Name
                                       && x.Id != model.Id
                                       && x.AccountId == userContext.GetAccountId()))
        {
            return await base.UpdateAsync(model);
        }

        await NotifyAsync("Já há uma categoria registrada com esse nome.");
        return null;
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