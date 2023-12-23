using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class AccountService(IRepository repository) :
    GenericService<AccountValidation, Account>(repository)
{
    public override async Task AddAsync(Account model)
    {
        if (!await RunValidationAsync(new AccountValidation(), model)) return;

        await base.AddAsync(model);
    }

    public override async Task UpdateAsync(Account model)
    {
        if (!await RunValidationAsync(new AccountValidation(), model)) return;

        await base.UpdateAsync(model);
    }
}