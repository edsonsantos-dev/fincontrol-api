using System.Net;
using FinControl.API.ViewModels;
using FinControl.API.ViewModels.InputViewModels.UserInputModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

public class AuthController(
    IAuthService service,
    INotifier notifier,
    IUserRepository userRepository) : BaseController(notifier)
{
    [HttpPost(nameof(SignIn))]
    public async Task<IActionResult> SignIn(LoginInputViewModel viewModel)
    {
        var user = await userRepository.GetByEmailAsync(viewModel.Email, viewModel.Password.GetPasswordHash());
        if (user == null)
        {
            NotifyError("Invalid email or password");
            return CustomResponse();
        }

        var accessToken = service.GenerateAccessToken(user);
        var refreshToken = service.GenerateRefreshToken(user);

        return CustomResponse(
            HttpStatusCode.Created,
            new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = 3600
            });
    }

    [HttpPost(nameof(RefreshToken))]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var result = await TokenExtensions.ValidateToken(refreshToken);
        if (result is not { IsValid: true })
        {
            NotifyError("Invalid refresh token");
            return CustomResponse();
        }

        var userId = result.Claims["UserId"].ToString();
        var user = await userRepository.GetByIdAsync(new Guid(userId!));
        if (user == null)
        {
            NotifyError("User not found");
            return CustomResponse();
        }

        var accessToken = service.GenerateAccessToken(user);
        var newRefreshToken = service.GenerateRefreshToken(user);

        return CustomResponse(
            HttpStatusCode.Created,
            new
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken,
                ExpiresIn = 3600
            });
    }
}