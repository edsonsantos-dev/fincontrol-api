using FinControl.Business.Models.AuditableEntities;

namespace FinControl.Business.Models;

public class Account : ModifiableEntity
{
    public List<User> Users { get; set; } = [];
    public List<Category>? Categories { get; set; }
    public List<Transaction>? Transactions { get; set; }
}