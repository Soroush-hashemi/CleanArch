using Domain.Base;

namespace Domain.Events;

public class UserRegistered : BaseDomainEvent
{
    public long Id { get; private set; }
    public Email Email { get; private set; }

    public UserRegistered(long userId, Email email)
    {
        Id = userId;
        Email = email;
    }
}
