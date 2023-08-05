using Domain.Base;
using Domain.Unit.Test.Builder;
using FluentAssertions;
using Xunit;

namespace Domain.Unit.Test.ValueObjectTest
{
    public class MoneyTest
    {
        [Fact]
        public void Constructor_Should_Set_Value_When_Value_Is_Bigger_Then_Zero()
        {
            var money = new Money(10000);

            money.Value.Should().Be(10000);
        }

        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyException_When_Value_Less_Then_Zero()
        {
            var result = () => new Money(-100);

            result.Should().Throw<NotImplementedException>().WithMessage("money is not valid");
        }

        [Fact]
        public void FromRial_Should_Create_New_Money_With_FromRial()
        {
            var money = Money.FromRial(10000);

            money.Value.Should().Be(10000);
        }

        [Fact]
        public void FromTooman_Should_Create_New_Money_With_FromTooman()
        {
            int TommanMoney = 10000;
            var money = Money.FromTooman(TommanMoney);
            money.Value.Should().Be(TommanMoney / 10);
        }

        [Fact]
        public void Plus_Must_Sum_Two_Numbers()
        {
            // arrange
            var moneyOne = Money.FromRial(10000);
            var moneyTwo = Money.FromRial(10000);

            // act
            var Result = moneyOne + moneyTwo;

            // assets
            Result.Value.Should().Be(20000);
        }

        [Fact]
        public void Minus_Must_Subtract_Two_Numbers()
        {
            // arrange
            var moneyOne = Money.FromRial(10000);
            var moneyTwo = Money.FromRial(11000);

            // act
            var Result = moneyTwo - moneyOne;

            // assets
            Result.Value.Should().Be(1000);
        }
    }
}