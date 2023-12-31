using FinControl.Business.Models;

namespace FinControl.API.ViewModels;

public class TransactionViewModel : ViewModelBase<Transaction>
{
    public decimal Amount { get; set; }
    public required string Description { get; set; }
    public int Installment { get; set; }

    public Guid CategoryId { get; set; }
    public CategoryViewModel? Category { get; set; }
    public Guid? RecurrenceId { get; set; }
    public RecurrenceViewModel? Recurrence { get; set; }
    public Guid? AccountId { get; set; }
    public Guid? UserId { get; set; }
    public UserViewModel? User { get; set; }
    
    public override Transaction ToModel()
    {
        return new Transaction
        {
            Amount = Amount,
            Description = Description,
            Installment = Installment,
            CategoryId = CategoryId,
            RecurrenceId = RecurrenceId,
            Recurrence = Recurrence?.ToModel(),
            Category = Category?.ToModel()!
        };
    }

    public static TransactionViewModel? FromModel(Transaction? model)
    {
        if (model == null) return null;
        
        return new TransactionViewModel
        {
            Id = model.Id,
            AddedOn = model.AddedOn,
            AddedBy = model.AddedBy,
            ModifiedOn = model.ModifiedOn,
            ModifiedBy = model.ModifiedBy,
            Amount = model.Amount,
            Description = model.Description,
            Installment = model.Installment,
            CategoryId = model.CategoryId,
            Category = CategoryViewModel.FromModel(model.Category),
            User = UserViewModel.FromModel(model.User),
            RecurrenceId = model.RecurrenceId,
            AccountId = model.AccountId,
            UserId = model.UserId
        };
    }
}