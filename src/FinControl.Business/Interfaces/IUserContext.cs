namespace FinControl.Business.Interfaces;

public interface IUserContext
{
    Guid GetUserId();
    Guid GetAccountId();
    bool IsAuthenticated();
}