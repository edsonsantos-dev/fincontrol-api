namespace FinControl.Business.Models;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public virtual Guid Id { get; set; }
    public DateTime AddedOn { get; set; }
    public Guid AddedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? RemoviedOn { get; set; }
    public Guid? RemoviedBy { get; set; }
}