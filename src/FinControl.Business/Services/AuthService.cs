using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinControl.Business.Interfaces;
using FinControl.Business.Models;
using FinControl.Shared.Config;
using Microsoft.IdentityModel.Tokens;

namespace FinControl.Business.Services;

public class AuthService : IAuthService
{
    public string GenerateAccessToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Instance!.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.Role, user.Role.ToString()),
                new("UserId", user.Id.ToString()),
                new("AccountId", user.AccountId.ToString())
            }),
            Issuer = Settings.Instance.Issuer,
            Audience = Settings.Instance.Audience,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(60),
            IssuedAt = DateTime.UtcNow,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            TokenType = Settings.Instance.TokenTypeAccessToken,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Instance!.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.Role, user.Role.ToString()),
                new("UserId", user.Id.ToString()),
                new("AccountId", user.AccountId.ToString())
            }),
            Issuer = Settings.Instance.Issuer,
            Audience = Settings.Instance.Audience,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddDays(30),
            IssuedAt = DateTime.UtcNow,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            TokenType = Settings.Instance.TokenTypeRefreshToken
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}