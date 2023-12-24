using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class TransactionService(
    ITransactionRepository repository,
    INotifier notifier)
    : GenericService<TransactionValidation, Transaction>(repository, notifier)
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