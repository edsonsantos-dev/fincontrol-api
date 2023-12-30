using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinControl.Data.Repository;

public class UserRepository(FinControlContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, string passwordHash)
    {
        return await Context.Users
            .FirstOrDefaultAsync(x => 
                x.Email == email && 
                x.PasswordHash == passwordHash);
    }
}