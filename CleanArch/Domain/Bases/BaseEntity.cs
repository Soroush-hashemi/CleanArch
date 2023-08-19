namespace Domain.Base;

public class BaseEntity
{
    public long Id { get; private set; }
    public DateTime CreationDate { get; }

    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
}
