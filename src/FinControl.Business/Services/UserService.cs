using System.Security.Cryptography;
using System.Text;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FinControl.Shared.Extensions;

namespace FinControl.Business.Services;

public class UserService(
    IUserRepository repository,
    INotifier notifier)
    : GenericService<UserValidation, User>(repository, notifier)
{
    public override async Task AddAsync(User model)
    {
        model.PasswordHash = model.PasswordHash.GetPasswordHash();
        
        await base.AddAsync(model);
    }
}