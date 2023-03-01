namespace Core.Domain;

public abstract class BaseEntity
{
    public string Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }

}
