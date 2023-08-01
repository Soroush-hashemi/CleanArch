using Domain.Base;

namespace Domain;

public class OrderItem : BaseEntity
{
    public long OrderId { get; protected set; }
    public int Count { get; private set; }
    public long ProductId { get; private set; }
    public Money Price { get; private set; }

    public OrderItem(long OrderId, int Count, long ProductId, Money Price)
    {
        OrderId = OrderId;
        Count = Count;
        ProductId = ProductId;
        Price = Price;
    }
}
