namespace Domain;

public class User : AggregateRoot
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string Family { get; private set; }

    public User(string name, string family, Email email)
    {
        Name = name;
        Family = family;
        Email = email;
    }

    public User Register(string name, Email email, string family)
    {
        var User = new User(name, family, email);
        User.AddDomainEvent(new UserRegistered(User.Id, User.Email));
        return User;
    }
}
