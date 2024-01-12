using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FinControl.Shared.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace FinControl.Business.Services;

public class UserService(
    IUserRepository repository,
    INotifier notifier)
    : GenericService<UserValidation, User>(repository, notifier), IUserService
{
    public override async Task<User?> AddAsync(User model)
    {
        if (model!.Email.EmailIsValid())
            return await base.AddAsync(model);

        await NotifyAsync("Informe um e-mail válido.");
        return null;
    }

    public override async Task<User?> UpdateAsync(User model)
    {
        if (model!.Email.EmailIsValid())
            return await base.UpdateAsync(model);

        await NotifyAsync("Informe um e-mail válido.");
        return null;
    }

    public async Task CreatePasswordAsync(Guid userId, string newPassword)
    {
        var user = await repository.GetByIdAsync(userId);

        if (user == null)
        {
            await NotifyAsync("Usuário não encontrado.");
            return;
        }

        if (!user.PasswordHash.IsNullOrEmpty())
        {
            await NotifyAsync("Senha já cadastrada.");
            return;
        }

        user.PasswordHash = newPassword.GetPasswordHash();
        await repository.UpdateAsync(user);
    }
    
    public async Task ChangePasswordAsync(string currentPassword, string newPassword)
    {
        var user = await repository.FindUserByUserIdAndPasswordHashAsync(currentPassword.GetPasswordHash());
        
        if (user == null)
        {
            await NotifyAsync("Usuário não encontrado.");
            return;
        }

        user.PasswordHash = newPassword.GetPasswordHash();
        await repository.UpdateAsync(user);
    }
    
    public async Task ResetPasswordAsync(string email)
    {
        var user = await repository.FindUserByEmailAsync(email);
        
        if (user == null)
        {
            await NotifyAsync("Usuário não encontrado.");
            return;
        }
        
        //TODO: Enviar e-mail para redefinir senha.
        throw new NotImplementedException();
    }

}