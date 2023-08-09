﻿using Domain.Base;
using Domain.Events;
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

    public void RegisterEvent(string name, Email email, string family)
    {
        var User = new User(name, family, email);
        AddDomainEvent(new UserRegistered(User.Id, User.Email));
    }

    public void Garud(string name, string family)
    {
        NullOrEmptyException.CheckString(name, "name");
        NullOrEmptyException.CheckString(family, "family");
    }
}
