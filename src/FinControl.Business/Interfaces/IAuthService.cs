using FinControl.Business.Models;

namespace FinControl.Business.Interfaces;

public interface IAuthService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}