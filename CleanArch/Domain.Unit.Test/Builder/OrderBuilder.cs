using Domain.Base;
using Domain.Entities;
using NSubstitute;

namespace Domain.Unit.Test.Builder
{
    internal class OrderBuilder
    {
        public IOrderDomainService CreateOrderDomainServiceReturnTrue()
        {
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductExist(Arg.Any<long>()).Returns(true); // یعنی محصول وجود دارد

            return orderDomainService;
        }

        public IOrderDomainService CreateOrderDomainServiceReturnFalse()
        {
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductExist(Arg.Any<long>()).Returns(false); // یعنی محصول وجود ندارد

            return orderDomainService;
        }

        public Order CreateOrder()
        {
            return new Order(1);
        }

        public OrderItem CreateOrderItem()
        {
            return new OrderItem(1, 2, 1, new Money(19000));
        }


    }
}
