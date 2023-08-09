using Domain.Unit.Test.Builder;
using FluentAssertions;
using Xunit;

namespace Domain.Unit.Test.ValueObjectTest
{
    public class EmailTest
    {
        private EmailBuilder _emailBuilder;
        public EmailTest()
        {
            _emailBuilder = new EmailBuilder();
        }

        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyException_When_Data_Was_Null()
        {
            var Email = () => _emailBuilder.CreateEmail("");

            Email.Should().ThrowExactly<NotImplementedException>().WithMessage("Email is null");
        }

        [Fact]
        public void Constructor_Should_Create_New_Email()
        {
            var Email = _emailBuilder.CreateEmail("Test@gmail.com");

            Email.EmailAddress.Should().Be("Test@gmail.com");
        }

        [Fact]
        public void FromGoogle_Should_Create_New_Google_Email()
        {
            var Email = _emailBuilder.FromGoogle("Test");

            Email.EmailAddress.Should().Be("Test@gmail.com");
        }

        [Fact]
        public void FromYahoo_Should_Create_New_Google_Email()
        {
            var Email = _emailBuilder.FromYahoo("Test");

            Email.EmailAddress.Should().Be("Test@Yahoo.com");
        }
    }
}
