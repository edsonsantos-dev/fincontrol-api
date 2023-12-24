using FinControl.Business.Models;

namespace FinControl.Business.Interfaces.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<Transaction?> GetTransactionByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> GetTransactionsAsync(Guid accountId);
}