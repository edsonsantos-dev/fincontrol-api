using FinControl.Business.Models;
using FinControl.Shared.Enums;

namespace FinControl.API.ViewModels.InputViewModels.UserInputModels;

public class UserInputViewModel : InputViewModelBase<User>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Password { get; set; }
    public string? WhatsAppNumber { get; set; }
    public bool IsActive { get; set; }
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
            Role = Role
        };
    }
}