using FinControl.Business.Models;

namespace FinControl.Business.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, string passwordHash);
}