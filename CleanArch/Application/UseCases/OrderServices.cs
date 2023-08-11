using Application.Common.Interfaces;
using Application.DTOs.Orders;
using Domain.Entities;
using Domain.Repositories;

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
            var order = new Order(command.UserId);
            _orderRepository.Add(order);
            _orderRepository.Save();
        }

        public void FinallyOrder(FinallyOrderDto command)
        {
            var order = _orderRepository.GetById(command.Id);
            order.Finally();
            _orderRepository.Update(order);
            _orderRepository.Save();
        }

        public OrderDto GetOrderById(long UserId)
        {
            var order = _orderRepository.GetById(UserId);
            return new OrderDto()
            {
                UserId = UserId,
                Count = order.Items.Count,
                Price = order.TotalItem,
                Id = order.Id,
                ProductId = order.ProductId
            };
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.GetAll().Select(order => new OrderDto()
            {
                UserId = order.UserId,
                Count = order.Items.Count,
                Price = order.TotalItem,
                Id = order.Id,
                ProductId = order.ProductId
            }).ToList();
        }
    }
}
