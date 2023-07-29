namespace Domain;

public class UserRegistered : BaseDomainEvent
{
    public long UserId { get; private set; }
    public Email Email { get; private set; }

    public UserRegistered(long userId, Email email)
    {
        UserId = userId;
        Email = email;
    }
}
