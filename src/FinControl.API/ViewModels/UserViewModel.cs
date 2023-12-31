using FinControl.Business.Models;
using FinControl.Shared.Enums;

namespace FinControl.API.ViewModels;

public class UserViewModel : ViewModelBase<User>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; }
    public string? WhatsAppNumber { get; set; }
    public string? FullName { get; set; }
    public bool IsActive { get; set; }

    public Guid AccountId { get; set; }
    public List<TransactionViewModel>? Transactions { get; set; }
    public UserRole Role { get; set; }

    public override User ToModel()
    {
        return new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PasswordHash = Password,
            WhatsAppNumber = WhatsAppNumber,
            IsActive = IsActive,
            AccountId = AccountId,
            Role = Role
        };
    }

    public static UserViewModel FromModel(User model)
    {
        return new UserViewModel
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            WhatsAppNumber = model.WhatsAppNumber,
            FullName = model.FullName,
            IsActive = model.IsActive,
            AccountId = model.AccountId,
            Transactions = model.Transactions?.Select(TransactionViewModel.FromModel).ToList(),
            Role = model.Role
        };
    }
}