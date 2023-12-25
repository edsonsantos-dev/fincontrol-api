using FinControl.Shared.Enums;

namespace FinControl.Business.Models;

public class Recurrence : AddableEntity
{
    public int Installment { get; set; }
    public RecurringFrequency Frequency { get; set; }

    public List<Transaction> Transactions { get; set; }
}