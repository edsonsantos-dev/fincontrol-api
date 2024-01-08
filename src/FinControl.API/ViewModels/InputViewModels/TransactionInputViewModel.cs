using FinControl.Business.Models;
using FinControl.Shared.Enums;

namespace FinControl.API.ViewModels.InputViewModels;

public class TransactionInputViewModel : InputViewModelBase<Transaction>
{
    public decimal Amount { get; set; }
    public required string Description { get; set; }
    public int Installment { get; set; }
    public DateTime DueDate { get; set; }
    public TransactionDirection Direction { get; set; }

    public Guid CategoryId { get; set; }
    public Guid? RecurrenceId { get; set; }
    public RecurrenceInputViewModel? Recurrence { get; set; }

    public override Transaction ToModel()
    {
        return new Transaction
        {
            Amount = Amount,
            Description = Description,
            Installment = Installment,
            DueDate = DueDate,
            Direction = Direction,
            CategoryId = CategoryId,
            RecurrenceId = RecurrenceId,
            Recurrence = Recurrence?.ToModel(),
        };
    }
}