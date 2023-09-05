using Domain.Base;
using System;

namespace Domain.Entities.UserAgg.Events;

public class UserEdited : BaseDomainEvent
{
    public long Id { get; private set; }
    public string Email { get; private set; }

    public UserEdited(long userId, string email)
    {
        Id = userId;
        Email = email;
    }
}