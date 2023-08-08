using Domain.Base;
using Domain.Exception;

namespace Domain;

public class Email : BaseValueObject
{
    public string EmailType { get; }
    public Email(string email)
    {
        NullOrEmptyException.CheckString(email, "Email");
        EmailType = email;
    }

    public static Email FromGoogle(string Email)
    {
        return new Email(Email + "gmail.com");
    }

    public static Email FromYahoo(string Email)
    {
        return new Email(Email + "Yahoo.com");
    }
}
