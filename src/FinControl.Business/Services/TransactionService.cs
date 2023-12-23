using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class TransactionService(IRepository repository)
    : GenericService<TransactionValidation, Transaction>(repository)
{
    public override async Task AddAsync(Transaction model)
    {
        if (!await RunValidationAsync(new TransactionValidation(), model)) return;

        await base.AddAsync(model);
    }

    public override async Task UpdateAsync(Transaction model)
    {
        if (!await RunValidationAsync(new TransactionValidation(), model)) return;
        
        await base.UpdateAsync(model);
    }
}