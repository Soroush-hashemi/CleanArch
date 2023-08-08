using Domain.Base;
using Domain.Exception;

namespace Domain;

public class User : AggregateRoot
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string Family { get; private set; }

    public User(string name, string family, Email email)
    {
        Garud(name, family);
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

    public void Garud(string name, string family)
    {
        NullOrEmptyException.CheckString(name, "name");
        NullOrEmptyException.CheckString(family, "family");
    }
}
