using Domain.Base;

namespace Domain;

public class OrderItem : BaseEntity
{
    private OrderItem()
    {
        
    }
    public long OrderId { get; protected set; }
    public int Count { get; private set; }
    public long ProductId { get; private set; }
    public Money Price { get; private set; }

    public OrderItem(long orderId, int count, long productId, Money price)
    {
        OrderId = orderId;
        Count = count;
        ProductId = productId;
        Price = price;
    }
}
