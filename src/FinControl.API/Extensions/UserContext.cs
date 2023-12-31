using System.Security.Claims;
using FinControl.Business.Interfaces;

namespace FinControl.API.Extensions;

public class UserContext(IHttpContextAccessor accessor) : IUserContext
{
    public Guid GetUserId()
    {
        return !IsAuthenticated()
            ? Guid.Empty
            : Guid.Parse(accessor.HttpContext!.User.FindFirstValue("UserId") ?? string.Empty);
    }

    public Guid GetAccountId()
    {
        return !IsAuthenticated()
            ? Guid.Empty
            : Guid.Parse(accessor.HttpContext!.User.FindFirstValue("AccountId") ?? string.Empty);
    }

    public bool IsAuthenticated()
    {
        return accessor.HttpContext?.User.Identity is { IsAuthenticated: true };
    }
}