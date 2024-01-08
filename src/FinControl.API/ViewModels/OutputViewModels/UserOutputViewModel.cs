using FinControl.Business.Models;
using FinControl.Shared.Enums;

namespace FinControl.API.ViewModels.OutputViewModels;

public class UserOutputViewModel : OutputViewModelBase<User>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? WhatsAppNumber { get; set; }
    public string? FullName { get; set; }
    public bool IsActive { get; set; }

    public Guid AccountId { get; set; }
    public List<TransactionOutputViewModel>? Transactions { get; set; }
    public UserRole Role { get; set; }

    public override TOutputViewModel FromModel<TOutputViewModel>(User? model)
    {
        if (model == null) return null;

        var outputViewModel = new UserOutputViewModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            WhatsAppNumber = model.WhatsAppNumber,
            FullName = model.FullName,
            IsActive = model.IsActive,
            AccountId = model.AccountId,
            Role = model.Role,
            Transactions = model.Transactions
                ?.Select(new TransactionOutputViewModel().FromModel<TransactionOutputViewModel>)
                .ToList(),
        };

        return outputViewModel as TOutputViewModel;
    }
}