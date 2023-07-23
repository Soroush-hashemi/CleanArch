using Application.Common.Interfaces;
using Application.DTOs.Orders;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObject.Sheard;

namespace Application.UseCases
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;

        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void AddOrder(AddOrderDto command)               
        {
            var order = new Order(command.ProductId, command.Count,new Money(command.Price));
            _orderRepository.Add(order);
            // _orderRepository.Save();
        }

        public void FinallyOrder(FinallyOrderDto command)
        {
            var order = _orderRepository.GetById(command.Id);
            order.Finally();
            _orderRepository.Update(order);
            // _orderRepository.Save();
        }

        public OrderDto GetOrderById(Guid id)
        {
            var order = _orderRepository.GetById(id);
            return new OrderDto()
            {
                Count = order.Count,
                Price = order.Price.Value,
                Id = order.Id,
                ProductId = order.ProductId
            };
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.GetAll().Select(order => new OrderDto()
            {
                Count = order.Count,
                Price = order.Price.Value,
                Id = order.Id,
                ProductId = order.ProductId
            }).ToList();
        }
    }
}
