using Domain.ValueObject.Sheard;

namespace Domain;

public class OrderItem
{
    public long Id { get; private set; }
    public Guid OrderId { get; protected set; }
    public int Count { get; private set; }
    public Guid ProductId { get; private set; }
    public Money Price { get; private set; }

    public OrderItem( Guid OrderId , int Count , Guid ProductId, Money Price)
    {
        OrderId = OrderId;
        Count = Count;
        ProductId = ProductId;
        Price = Price;
    }
}
