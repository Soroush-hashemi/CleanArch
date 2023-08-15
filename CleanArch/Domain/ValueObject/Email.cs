using Domain.Base;
using Domain.Exception;

namespace Domain;

public class Email : BaseValueObject
{
    private Email()
    {
        
    }
    public string EmailAddress { get; set; }
    public Email(string email)
    {
        NullOrEmptyException.CheckString(email, "Email");
        EmailAddress = email;
    }

    public static Email FromGoogle(string Email)
    {
        return new Email(Email + "@gmail.com");
    }

    public static Email FromYahoo(string Email)
    {
        return new Email(Email + "@Yahoo.com");
    }
}
