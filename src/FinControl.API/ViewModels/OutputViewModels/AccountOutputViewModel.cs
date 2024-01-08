using FinControl.Business.Models;

namespace FinControl.API.ViewModels.OutputViewModels;

public class AccountOutputViewModel : OutputViewModelBase<Account>
{
    public List<UserOutputViewModel>? Users { get; set; } = [];
    public List<CategoryOutputViewModel>? Categories { get; set; }
    public List<TransactionOutputViewModel>? Transactions { get; set; }

    public override TOutputViewModel FromModel<TOutputViewModel>(Account model)
    {
        var outputViewModel = new AccountOutputViewModel
        {
            Users = model.Users?.Select(new UserOutputViewModel().FromModel<UserOutputViewModel>)
                .ToList(),
            Categories = model.Categories?.Select(new CategoryOutputViewModel().FromModel<CategoryOutputViewModel>)
                .ToList(),
            Transactions = model.Transactions?.Select(new TransactionOutputViewModel().FromModel<TransactionOutputViewModel>)
                .ToList(),
        };

        return outputViewModel as TOutputViewModel;
    }
}