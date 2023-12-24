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
        return await context.Transactions
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync(Guid accountId)
    {
        return await context.Transactions
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.User)
            .Where(x => x.AccountId == accountId)
            .ToListAsync();
    }
}