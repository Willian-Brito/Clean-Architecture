namespace Core.Domain;

public abstract class EntityBase
{
    public DateTime CreatedDate { get; protected set; }
    public DateTime? ModifiedDate { get; protected set; }
    public string? CreatedBy { get; protected set; }
    public string? ModifiedBy { get; protected set; }
}
