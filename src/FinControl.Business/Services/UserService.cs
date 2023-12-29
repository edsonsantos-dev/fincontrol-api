using System.Security.Cryptography;
using System.Text;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Services;

public class UserService(
    IRepository<User> repository,
    INotifier notifier)
    : GenericService<UserValidation, User>(repository, notifier), IUserService
{
    public override async Task AddAsync(User model)
    {
        if (!await RunValidationAsync(new UserValidation(), model)) return;
        
        model.PasswordHash = GeneretePasswordHash(model.PasswordHash);
        await base.AddAsync(model);
    }

    public override async Task UpdateAsync(User model)
    {
        if (!await RunValidationAsync(new UserValidation(), model)) return;

        await base.UpdateAsync(model);
    }

    public void GeneretePasswordHash(User model)
    {
        model.PasswordHash = GeneretePasswordHash(model.PasswordHash);
    }

    private static string GeneretePasswordHash(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var builder = new StringBuilder();

        foreach (var t in bytes)
            builder.Append(t.ToString("x2"));

        return builder.ToString();
    }
}