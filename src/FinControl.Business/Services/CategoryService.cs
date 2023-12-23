using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class CategoryService(IRepository repository) :
    GenericService<CategoryValidation, Category>(repository)
{
    public override async Task AddAsync(Category model)
    {
        if (!await RunValidationAsync(new CategoryValidation(), model)) return;

        await base.AddAsync(model);
    }

    public override async Task UpdateAsync(Category model)
    {
        if (!await RunValidationAsync(new CategoryValidation(), model)) return;

        await base.UpdateAsync(model);
    }
}