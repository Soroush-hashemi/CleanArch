using Domain.ValueObject.Sheard;

namespace Domain;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; protected set; }
    public int Count { get; private set; }
    public Guid ProductId { get; private set; }
    public Money Price { get; private set; }

    public OrderItem(long OrderId, int Count, long ProductId, Money Price)
    {
        OrderId = OrderId;
        Count = Count;
        ProductId = ProductId;
        Price = Price;
    }
}
