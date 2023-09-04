using Domain.Base;

namespace Domain.Entities.ProductAgg.Events;
public class ProductDeleted : BaseDomainEvent
{
    public long Id { get; set; }
    public ProductDeleted(long id)
    {
        Id = id;
    }
}