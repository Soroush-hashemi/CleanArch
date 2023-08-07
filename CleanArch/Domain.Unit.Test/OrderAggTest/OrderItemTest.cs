
using Domain.Base;
using Domain.Unit.Test.Builder;
using FluentAssertions;
using Xunit;

namespace Domain.Unit.Test.OrderAggTest
{
    public class OrderItemTest
    {
        private OrderBuilder _orderbuilder;
        public OrderItemTest()
        {
            _orderbuilder = new OrderBuilder();
        }

        //OrderItem(1, 2, 1, new Money(19000));

        [Fact]
        public void Constructor_Should_Set_OrderId_In_OrderItem()
        {
            var OrderItem = _orderbuilder.CreateOrderItem();

            OrderItem.OrderId.Should().Be(1);
        }

        [Fact]
        public void Constructor_Should_Set_Count_In_OrderItem()
        {
            var OrderItem = _orderbuilder.CreateOrderItem();

            OrderItem.Count.Should().Be(2);
        }

        [Fact]
        public void Constructor_Should_Set_ProductId_In_OrderItem()
        {
            var OrderItem = _orderbuilder.CreateOrderItem();

            OrderItem.ProductId.Should().Be(1);
        }

        [Fact]
        public void Constructor_Should_Set_Price_In_OrderItem()
        {
            var OrderItem = _orderbuilder.CreateOrderItem();

            OrderItem.Price.Value.Should().Be(19000);
        }
    }
}
