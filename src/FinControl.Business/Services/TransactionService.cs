using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FinControl.Shared.Extensions;

namespace FinControl.Business.Services;

public class TransactionService(
    ITransactionRepository repository,
    INotifier notifier)
    : GenericService<TransactionValidation, Transaction>(repository, notifier)
{
    public override async Task AddAsync(Transaction model)
    {
        if (model.Recurrence is not { Installment: > 1 })
        {
            await base.AddAsync(model);
        }
        else
        {
            var transactions = BuildTransactions(model);

            foreach (var transaction in transactions)
            {
                if (!await RunValidationAsync(new TransactionValidation(), transaction))
                    return;
            }

            await base.AddRangeAsync(transactions);
        }
    }

    public override async Task UpdateAsync(Transaction model)
    {
        if (!await RunValidationAsync(new TransactionValidation(), model)) return;

        await base.UpdateAsync(model);
    }

    private static List<Transaction> BuildTransactions(Transaction model)
    {
        List<Transaction> transactions = [];

        for (var i = 1; i <= model.Recurrence!.Installment; i++)
        {
            var transaction = new Transaction
            {
                Amount = model.Amount,
                Description = $"{model.Description} - {i}/{model.Recurrence.Installment}",
                Installment = i,
                DueDate = model.DueDate.CalculateNextDueDate(model.Recurrence.Frequency, i - 1),
                CategoryId = model.CategoryId,
                RecurrenceId = model.RecurrenceId
            };

            transactions.Add(transaction);
        }

        return transactions;
    }
}