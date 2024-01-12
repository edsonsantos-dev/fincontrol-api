using FinControl.API.ViewModels.InputViewModels.UserInputModels;
using FinControl.API.ViewModels.OutputViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

public class UserController(
    INotifier notifier,
    IUserRepository repository,
    IUserService service)
    : GenericController<UserInputViewModel, UserOutputViewModel, User, UserValidation>
        (notifier, repository, service)
{
    [HttpPut(nameof(CreatePassword))]
    [AllowAnonymous]
    public async Task<IActionResult> CreatePassword(Guid userId, string newPassword)
    {
        await service.CreatePasswordAsync(userId, newPassword);
        return CustomResponse();
    }

    [HttpPut(nameof(ChangePassword))]
    [Authorize]
    public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
    {
        await service.ChangePasswordAsync(currentPassword, newPassword);
        return CustomResponse();
    }

    [HttpPut(nameof(ResetPassword))]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(string email)
    {
        await service.ResetPasswordAsync(email);
        return CustomResponse();
    }
}