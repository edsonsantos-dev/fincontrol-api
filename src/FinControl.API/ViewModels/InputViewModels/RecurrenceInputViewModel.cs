using FinControl.Business.Models;
using FinControl.Shared.Enums;

namespace FinControl.API.ViewModels.InputViewModels;

public class RecurrenceInputViewModel : InputViewModelBase<Recurrence>
{
    public int Installment { get; set; }
    public RecurringFrequency Frequency { get; set; }

    public override Recurrence ToModel()
    {
        return new Recurrence
        {
            Installment = Installment,
            Frequency = Frequency
        };
    }
}