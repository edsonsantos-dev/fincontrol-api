using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class UserService(
    IRepository<User> repository,
    INotifier notifier)
    : GenericService<UserValidation, User>(repository, notifier)
{
    public override async Task AddAsync(User model)
    {
        if (!await RunValidationAsync(new UserValidation(), model)) return;

        await base.AddAsync(model);
    }

    public override async Task UpdateAsync(User model)
    {
        if (!await RunValidationAsync(new UserValidation(), model)) return;

        await base.UpdateAsync(model);
    }
}