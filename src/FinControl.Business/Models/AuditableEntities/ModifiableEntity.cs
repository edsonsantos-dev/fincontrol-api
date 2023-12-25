namespace FinControl.Business.Models;

public class ModifiableEntity : AddableEntity
{
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }
}