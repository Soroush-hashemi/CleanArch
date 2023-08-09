using Domain.Unit.Test.Builder;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Unit.Test.UserAggTest
{
    public class UserTest
    {
        private UserBuilder _userBuilder;
        public UserTest()
        {
            _userBuilder = new UserBuilder();
        }

        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyException_When_Data_Was_Null()
        {
            var User = () => _userBuilder.CreateUser("","","test@gmail.com");

            User.Should().ThrowExactly<NotImplementedException>();
        }

        [Fact]
        public void Constructor_Should_Create_New_User()
        {
            var User = _userBuilder.CreateUser("soroush","hashemi","Test@gmail.com");

            User.Name.Should().Be("soroush");
            User.Family.Should().Be("hashemi");
        }


        [Fact]
        public void RegisterEvent_Should_Create_AddDomainEvent()
        {
            var User = _userBuilder.CreateUser("soroush", "hashemi", "Test@gmail.com");

            User.RegisterEvent("soroush", new Email("Test@gmail.com"), "hashemi");

            User.DomainEvents.Should().HaveCount(1);
        }
    }
}
