﻿using Domain.Base;

namespace Domain.Entities.OrderAgg.Events;

public class OrderFinalized : BaseDomainEvent
{
    public long OrderId { get; set; }
    public long UserId { get; set; }
    public OrderFinalized(long orderId, long userId)
    {
        OrderId = orderId;
        UserId = userId;
    }
}