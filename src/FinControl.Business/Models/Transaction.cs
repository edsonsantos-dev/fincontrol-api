using FinControl.Business.Models.AuditableEntities;

namespace FinControl.Business.Models;

public class Transaction : RemovableEntity
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int Installment { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid? RecurrenceId { get; set; }
    public Recurrence? Recurrence { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}