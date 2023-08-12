using Application.Unit.Test.Builder;
using Application.UseCases;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Application.Unit.Test.UseCases
{
    public class OrderServicesTest
    {
        private readonly OrderServiceBuilder _builder;
        private readonly OrderServices _orderServices;
        private readonly IOrderRepository _repository;
        public OrderServicesTest()
        {
            _builder = new OrderServiceBuilder();
            _repository = Substitute.For<IOrderRepository>();
            _orderServices = new(_repository);
        }

        [Fact]
        public void AddOrder_Should_Add_Order()
        {
            var command = _builder.CreateAddOrderDto(1, 1, 10000, 2);

            _orderServices.AddOrder(command);

            _repository.Received(1).Save();
        }

        [Fact]
        public void FinallyOrder_Should_Finally_Order()
        {
            _repository.GetById(Arg.Any<long>()).Returns(new Order(1));
            var command = _builder.CreateFinallyOrderDto(1);

            _orderServices.FinallyOrder(command);

            _repository.Received(1).Save();
        }

        [Fact]
        public void GetOrderById_Should_GetOrder_By_Id()
        {
            _repository.GetById(Arg.Any<long>()).Returns(new Order(2));

            var order = _orderServices.GetOrderById(1);

            order.UserId.Should().Be(1);
        }

        [Fact]
        public void GetOrders_Should_Get_List_Of_Order()
        {
            _repository.GetAll().Returns(
                new List<Order>(){
                    new Order(1),
                    new Order(2)
                });

            var result = _orderServices.GetOrders();
            result.Should().HaveCount(2);
        }
    }
}
