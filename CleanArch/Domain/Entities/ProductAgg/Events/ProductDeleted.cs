using Domain.Base;

namespace Domain.Entities.ProductAgg.Events;
internal class ProductDeleted : BaseDomainEvent
{
    public long Id { get; set; }
    public ProductDeleted(long id)
    {
        Id = id;
    }
}