using Domain.Base;
using Domain.Entities;
using Domain.Service;
using NSubstitute;

namespace Domain.Unit.Test.Builder
{
    internal class OrderBuilder
    {
        public IProductExist CreateOrderDomainServiceReturnTrue()
        {
            var orderDomainService = Substitute.For<IProductExist>();
            orderDomainService.IsProductExist(Arg.Any<long>()).Returns(true); // یعنی محصول وجود دارد

            return orderDomainService;
        }

        public IProductExist CreateOrderDomainServiceReturnFalse()
        {
            var orderDomainService = Substitute.For<IProductExist>();
            orderDomainService.IsProductExist(Arg.Any<long>()).Returns(false); // یعنی محصول وجود ندارد

            return orderDomainService;
        }

        public Order CreateOrder()
        {
            var userDomainService = Substitute.For<IUserExist>();
            userDomainService.IsUserExsit(Arg.Any<long>()).Returns(true);

            return new Order(1, userDomainService);
        }

        public OrderItem CreateOrderItem()
        {
            return new OrderItem(1, 2, 1, new Money(19000));
        }


    }
}
