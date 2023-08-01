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
            var order = new Order(command.ProductId);
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

        public OrderDto GetOrderById(long id)
        {
            var order = _orderRepository.GetById(id);
            return new OrderDto()
            {
                Count = order.Items.Count,
                Price = order.TotalPrice,
                Id = order.Id,
                ProductId = order.ProductId
            };
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.GetAll().Select(order => new OrderDto()
            {
                Count = order.Items.Count,
                Price = order.TotalPrice,
                Id = order.Id,
                ProductId = order.ProductId
            }).ToList();
        }
    }
}
