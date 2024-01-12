using FinControl.Business.Models;

namespace FinControl.Business.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindUserByEmailAndPasswordHashAsync(string email, string passwordHash);
    Task<User?> FindUserByUserIdAndPasswordHashAsync(string passwordHash);
    Task<User?> FindUserByEmailAsync(string email);
}