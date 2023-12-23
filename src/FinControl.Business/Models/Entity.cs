namespace FinControl.Business.Models;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public virtual Guid Id { get; set; }
}