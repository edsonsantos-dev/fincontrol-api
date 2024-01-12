using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Interfaces;

public interface IUserService : IGenericService<UserValidation, User>
{
    Task CreatePasswordAsync(Guid userId, string newPassword);
    Task ChangePasswordAsync(string currentPassword, string newPassword);
    Task ResetPasswordAsync(string email);
}