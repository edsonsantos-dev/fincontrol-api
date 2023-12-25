using FinControl.Business.Models.AuditableEntities;
using FinControl.Business.Models.Enums;

namespace FinControl.Business.Models;

public class Recurrence : AddableEntity
{
    public int Installment { get; set; }
    public RecurringFrequency Frequency { get; set; }

    public List<Transaction> Transactions { get; set; }
}