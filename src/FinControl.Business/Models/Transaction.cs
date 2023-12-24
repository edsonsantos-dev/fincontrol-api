namespace FinControl.Business.Models;

public class Transaction : AuditableEntity
{
    public decimal Amount { get; set; }
    public string Description { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}