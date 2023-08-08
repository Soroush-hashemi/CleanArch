
namespace Domain.Unit.Test.Builder
{
    public class EmailBuilder
    {
        public Email CreateEmail(string Email)
        {
            return new Email(Email);
        }

        public Email FromGoogle(string email)
        {
            var EmailGooglr = Email.FromGoogle(email);
            return EmailGooglr;
        }

        public Email FromYahoo(string email)
        {
            var EmailGooglr = Email.FromYahoo(email);
            return EmailGooglr;
        }
    }
}
