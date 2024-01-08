using FinControl.API.ViewModels.InputViewModels.UserInputModels;
using FinControl.Business.Models;

namespace FinControl.API.ViewModels.InputViewModels;

public class AccountInputModel : InputViewModelBase<Account>
{
    public required UserInputViewModel User { get; set; }

    public override Account ToModel()
    {
        return new Account
        {
            Users = [User.ToModel()]
        };
    }
}