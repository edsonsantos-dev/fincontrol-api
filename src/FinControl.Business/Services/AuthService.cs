using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinControl.Business.Interfaces;
using FinControl.Business.Models;
using FinControl.Business.Notifications;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace FinControl.Business.Services;

public class AuthService(INotifier notifier) : IAuthService
{
    public string GenerateAccessToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("7b48f42f-3c13-4cf9-94f3-4a08124b7a75");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("AccountId", user.AccountId.ToString())
            }),
            Issuer = "https://fincontrol.dev",
            Audience = "FinControl.API",
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(60),
            IssuedAt = DateTime.UtcNow,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            TokenType = "at+jwt"
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("7b48f42f-3c13-4cf9-94f3-4a08124b7a75");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("AccountId", user.AccountId.ToString())
            }),
            Issuer = "https://fincontrol.dev",
            Audience = "FinControl.API",
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddDays(30),
            IssuedAt = DateTime.UtcNow,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            TokenType = "rt+jwt"
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<TokenValidationResult?> ValidateToken(string refreshToken)
    {
        var handler = new JsonWebTokenHandler();
        var key = Encoding.ASCII.GetBytes("7b48f42f-3c13-4cf9-94f3-4a08124b7a75");

        var result = await handler.ValidateTokenAsync(refreshToken, new TokenValidationParameters
        {
            ValidIssuer = "https://fincontrol.dev",
            ValidAudience = "FinControl.API",
            RequireSignedTokens = false,
            IssuerSigningKey = new SymmetricSecurityKey(key),
        });

        if (!result.IsValid)
            notifier.AddNotification(new Notification("Expired token"));

        return result;
    }
}