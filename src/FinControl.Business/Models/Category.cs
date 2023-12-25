namespace FinControl.Business.Models;

public class Category : RemovableEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public List<Transaction>? Transactions { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}