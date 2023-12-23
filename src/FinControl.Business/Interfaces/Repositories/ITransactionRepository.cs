using FinControl.Business.Models;

namespace FinControl.Business.Interfaces.Repositories;

public interface ITransactionRepository : IRepository
{
    Task<IEnumerable<Transaction>> GetTransactionsByCategoryIdAsync(Guid categoryId);
    Task<IEnumerable<Transaction>> GetTransactionsByRegisteredUserIdAsync(Guid userId);
}