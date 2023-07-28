namespace Domain.Entities;

public class OrderFinalized : BaseDomainEvent
{
    public long OrderId { get; set; }
    public long UserId { get; set; }
    public OrderFinalized(long orderId, long userId)
    {
        userId = UserId;
        OrderId = OrderId;
    }
}
