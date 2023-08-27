using Domain.Base;

namespace Domain.Entities.UserAgg.Events;

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
