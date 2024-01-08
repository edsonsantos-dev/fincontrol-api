using FinControl.Business.Models;

namespace FinControl.API.ViewModels.OutputViewModels;

public class CategoryOutputViewModel : OutputViewModelBase<Category>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<TransactionOutputViewModel>? Transactions { get; set; }
    public UserOutputViewModel? User { get; set; }

    public override TOutputViewModel FromModel<TOutputViewModel>(Category? model)
    {
        if (model == null) return null;
        
        var outputViewModel = new CategoryOutputViewModel
        {
            Id = model.Id,
            Name = model.Name,
            IsActive = model.IsActive,
            AddedOn = model.AddedOn,
            AddedBy = model.AddedBy,
            ModifiedOn = model.ModifiedOn,
            ModifiedBy = model.ModifiedBy,
            User = new UserOutputViewModel().FromModel<UserOutputViewModel>(model.User),
            Transactions = model.Transactions
                ?.Select(new TransactionOutputViewModel().FromModel<TransactionOutputViewModel>).ToList()
        };

        return outputViewModel as TOutputViewModel;
    }
}