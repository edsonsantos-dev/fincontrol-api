using System.Text;
using FinControl.Shared.Config;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace FinControl.Shared.Extensions;

public static class TokenExtensions
{
    public static async Task<TokenValidationResult?> ValidateToken(string refreshToken)
    {
        var handler = new JsonWebTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Instance!.Secret);

        var result = await handler.ValidateTokenAsync(refreshToken, new TokenValidationParameters
        {
            ValidIssuer = Settings.Instance.Issuer,
            ValidAudience = Settings.Instance.Audience,
            RequireSignedTokens = false,
            IssuerSigningKey = new SymmetricSecurityKey(key),
        });
        return result;
    }
}