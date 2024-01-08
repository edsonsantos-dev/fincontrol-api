using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinControl.Data.Repository;

public class TransactionRepository(
    FinControlContext context)
    : Repository<Transaction>(context), ITransactionRepository
{
    public async Task<Transaction?> GetTransactionByIdAsync(Guid id)
    {
        return await Context.Transactions
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Recurrence)
            .FirstOrDefaultAsync(x => x.Id == id && x.RemovedOn == null);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
    {
        try
        {
            return await Context.Transactions
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Recurrence)
                .Where(x => x.AccountId == Context.AccountId && x.RemovedOn == null)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}