namespace FinControl.Business.Models;

public class Category : AuditableEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    
    public List<Transaction> Transactions { get; set; } = [];

    public Guid AccountId { get; set; }
}