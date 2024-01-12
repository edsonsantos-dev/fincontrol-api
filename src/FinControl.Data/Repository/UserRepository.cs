using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinControl.Data.Repository;

public class UserRepository(FinControlContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> FindUserByEmailAndPasswordHashAsync(string email, string passwordHash)
    {
        return await Context.Users
            .FirstOrDefaultAsync(x => 
                x.Email == email && 
                x.PasswordHash == passwordHash);
    }

    public async Task<User?> FindUserByUserIdAndPasswordHashAsync(string passwordHash)
    {
        return await Context.Users
            .FirstOrDefaultAsync(x =>
                x.Id == context.UserId &&
                x.PasswordHash == passwordHash);
    }

    public async Task<User?> FindUserByEmailAsync(string email)
    {
        return await Context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}