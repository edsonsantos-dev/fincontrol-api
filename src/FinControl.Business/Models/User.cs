using FinControl.Shared.Enums;

namespace FinControl.Business.Models;

public class User : ModifiableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? WhatsAppNumber { get; set; }
    public bool? ConfirmedWhatsAppNumber { get; set; }
    public string PasswordHash { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public bool IsActive { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public List<Transaction>? Transactions { get; set; }
    public UserRole Role { get; set; }

    public void SetIdToAccountIdIfOwner()
    {
        if (Role == UserRole.Owner)
            Id = AccountId;
    }
}