using FinControl.Business.Models;

namespace FinControl.API.ViewModels;

public class AccountViewModel
{
    public List<UserViewModel>? Users { get; set; } = [];
    public List<CategoryViewModel>? Categories { get; set; }
    public List<TransactionViewModel>? Transactions { get; set; }

    public Account ToModel()
    {
        return new Account
        {
            Users = Users.Select(x => x.ToModel()).ToList()
        };
    }

    public static AccountViewModel FromModel(Account model)
    {
        return new AccountViewModel
        {
            Users = model.Users?.Select(UserViewModel.FromModel).ToList(),
            Categories = model.Categories?.Select(CategoryViewModel.FromModel).ToList(),
            Transactions = model.Transactions?.Select(TransactionViewModel.FromModel).ToList()
        };
    }
}