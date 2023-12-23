namespace FinControl.Business.Models;

public abstract class AuditableEntity : Entity
{
    public DateTime AddedOn { get; set; }
    public Guid AddedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? RemovedOn { get; set; }
    public Guid? RemovedBy { get; set; }
}