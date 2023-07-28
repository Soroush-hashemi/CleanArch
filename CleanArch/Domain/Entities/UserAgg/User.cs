namespace Domain;

public class User : AggregateRoot
{
    public string Name { get; private set;}
    public string Phone { get; private set;}
    public string Family { get; private set; }

    public User(string name, string family, string phone)
    {
        Name = name;
        Family = family;
        Phone = phone;
    }
}
