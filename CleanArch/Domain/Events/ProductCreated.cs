using Domain.Base;
using System;
using System.Collections.Generic;

namespace Domain.Events;

public class ProductCreated : BaseDomainEvent
{
    public string Title { get; set; }
    public long Id { get; set; }
    public ProductCreated(long id, string title)
    {
        Id = id;
        Title = title;
    }
}
