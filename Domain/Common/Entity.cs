namespace Domain.Entities;

public class Entity
{
    protected Entity() {}
    public int Id { get; protected set; }
    public DateTime CreationDateTime { get; protected set; }
}