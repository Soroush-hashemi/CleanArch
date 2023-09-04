using Domain.Base;
using System;

namespace Domain.Entities.UserAgg.Events;

internal class UserEdited : BaseDomainEvent
{
    public long Id { get; private set; }
    public Email Email { get; private set; }

    public UserEdited(long userId, Email email)
    {
        Id = userId;
        Email = email;
    }
}