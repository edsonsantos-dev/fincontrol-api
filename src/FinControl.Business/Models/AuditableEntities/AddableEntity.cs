namespace FinControl.Business.Models;

public class AddableEntity : Entity
{
    public DateTime AddedOn { get; set; }
    public Guid AddedBy { get; set; }
}