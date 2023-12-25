namespace FinControl.Business.Models.AuditableEntities;

public class AddableEntity : Entity
{
    public DateTime AddedOn { get; set; }
    public Guid AddedBy { get; set; }
}