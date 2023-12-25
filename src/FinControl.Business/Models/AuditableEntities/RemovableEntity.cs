namespace FinControl.Business.Models.AuditableEntities;

public class RemovableEntity : ModifiableEntity
{
    public DateTime? RemovedOn { get; set; }
    public Guid? RemovedBy { get; set; }
}