using FinControl.Business.Models;
using Microsoft.IdentityModel.Tokens;

namespace FinControl.Business.Interfaces;

public interface IAuthService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
    Task<TokenValidationResult?> ValidateToken(string refreshToken);
}