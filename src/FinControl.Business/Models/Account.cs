namespace FinControl.Business.Models;

public class Account : AuditableEntity
{
    public List<User> Users { get; set; } = [];
    public List<Category>? Categories { get; set; }
    public List<Transaction>? Transactions { get; set; }
}