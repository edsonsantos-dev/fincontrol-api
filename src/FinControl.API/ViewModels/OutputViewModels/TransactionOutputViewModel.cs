using FinControl.Business.Models;
using FinControl.Shared.Enums;

namespace FinControl.API.ViewModels.OutputViewModels;

public class TransactionOutputViewModel : OutputViewModelBase<Transaction>
{
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public int Installment { get; set; }
    public DateTime DueDate { get; set; }
    public TransactionDirection Direction { get; set; }

    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public Guid? RecurrenceId { get; set; }
    public Guid? AccountId { get; set; }

    public override TOutputViewModel FromModel<TOutputViewModel>(Transaction? model)
    {
        try
        {
            if (model == null) return null;

            var outputViewModel = new TransactionOutputViewModel
            {
                Id = model.Id,
                AddedOn = model.AddedOn,
                AddedBy = model.AddedBy,
                ModifiedOn = model.ModifiedOn,
                ModifiedBy = model.ModifiedBy,
                Amount = model.Amount,
                Description = model.Description,
                Installment = model.Installment,
                DueDate = model.DueDate,
                Direction = Direction,
                CategoryId = model?.Category?.Id,
                CategoryName = model?.Category?.Name,
                UserId = model?.User?.Id,
                UserName = model?.User?.FullName,
                RecurrenceId = model.RecurrenceId,
                AccountId = model.AccountId,
            };

            return outputViewModel as TOutputViewModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}