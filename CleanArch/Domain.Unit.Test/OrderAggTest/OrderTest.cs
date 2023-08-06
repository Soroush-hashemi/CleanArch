using Domain.Entities;
using Domain.Exception;
using Domain.Unit.Test.Builder;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Domain.Unit.Test.OrderAggTest
{
    public class OrderTest
    {
        private OrderBuilder _orderbuilder;
        public OrderTest()
        {
            _orderbuilder = new OrderBuilder();
        }

        [Fact]
        public void Constructor_Should_Create_Order()
        {
            var order = _orderbuilder.CreateOrder();

            order.UserId.Should().Be(1);
            order.IsFinally.Should().Be(false);
        }

        [Fact]
        public void Finally_Should_Be_Ture()
        {
            var order = _orderbuilder.CreateOrder();

            order.Finally();

            order.IsFinally.Should().Be(true);
        }

        [Fact]
        public void Finally_Should_Create_AddDomainEvent()
        {
            var order = _orderbuilder.CreateOrder();

            order.Finally();

            order.DomainEvents.Should().HaveCount(1);
        }

        [Fact]
        public void AddItem_Should_Throw_ProductNotFoundException_When_Product_DoNot_Exist()
        {
            var order = _orderbuilder.CreateOrder();
            var orderDomainService = _orderbuilder.CreateOrderDomainServiceReturnFalse();

            var result = () => order.AddItem(1 ,4 ,50000, orderDomainService);

            result.Should().ThrowExactly<NotImplementedException>("product not exist");
        }

        [Fact]
        public void AddItem_Should_Add_New_Item_To_Order()
        {
            var order = _orderbuilder.CreateOrder();
            var orderDomainService = _orderbuilder.CreateOrderDomainServiceReturnTrue();

            order.AddItem(1, 4, 50000, orderDomainService);

            order.TotalItem.Should().Be(4);
        }


        [Fact]
        public void RemoveItem_Should_Throw_NullOrEmptyException_When_Item_DoNot_Exist()
        {
            var order = _orderbuilder.CreateOrder();

            var result = () => order.RemoveItem(1);

            result.Should().ThrowExactly<NotImplementedException>("is not valid");
        }

        [Fact]
        public void RemoveItem_Should_RemoveItem_When_Data_WasOk()
        {
            var order = _orderbuilder.CreateOrder();
            var orderDomainService = _orderbuilder.CreateOrderDomainServiceReturnTrue();

            order.AddItem(1, 4, 50000, orderDomainService);
            order.RemoveItem(1);

            order.TotalItem.Should().Be(0);
        }
    }
}
