using FinControl.Business.Models;

namespace FinControl.API.ViewModels;

public class CategoryViewModel : ViewModelBase<Category>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public Guid AccountId { get; set; }
    public UserViewModel? User { get; set; }
    public Guid UserId { get; set; }
    public List<TransactionViewModel>? Transactions { get; set; }

    public override Category ToModel()
    {
        return new Category
        {
            Name = Name,
            IsActive = IsActive
        };
    }

    public static CategoryViewModel FromModel(Category model)
    {
        return new CategoryViewModel
        {
            Id = model.Id,
            IsActive = model.IsActive,
            AddedOn = model.AddedOn,
            AddedBy = model.AddedBy,
            ModifiedOn = model.ModifiedOn,
            ModifiedBy = model.ModifiedBy,
            UserId = model.UserId,
            User = UserViewModel.FromModel(model.User),
            AccountId = model.AccountId,
            Transactions = model.Transactions?.Select(TransactionViewModel.FromModel).ToList()
        };
    }
}