namespace FinControl.Business.Models;

public class RemovableEntity : ModifiableEntity
{
    public DateTime? RemovedOn { get; set; }
    public Guid? RemovedBy { get; set; }
}