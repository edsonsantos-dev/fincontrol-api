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
    public override async Task AddAsync(Account model)
    {
        if (!await RunValidationAsync(new AccountValidation(), model)) return;

        var user = model.Users.FirstOrDefault();
        user.PasswordHash = user.PasswordHash.GetPasswordHash();

        if (!user.Email.EmailIsValid())
        {
            await NotifyAsync("Informe um e-mail válido.");
            return;
        }
        
        await base.AddAsync(model);
    }
}