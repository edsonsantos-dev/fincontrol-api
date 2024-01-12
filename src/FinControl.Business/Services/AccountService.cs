using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FinControl.Shared.Extensions;

namespace FinControl.Business.Services;

public class AccountService(
    IRepository<Account> repository,
    INotifier notifier) :
    GenericService<AccountValidation, Account>(repository, notifier)
{
    public override async Task<Account?> AddAsync(Account model)
    {
        var user = model.Users.FirstOrDefault();

        if (user!.Email.EmailIsValid())
            return await base.AddAsync(model);

        await NotifyAsync("Informe um e-mail válido.");
        return null;
    }
}