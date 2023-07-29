namespace Domain;

public class Email
{
    public string EmailType { get; }
    public Email(string email)
    {
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
