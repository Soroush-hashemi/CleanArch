using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderItemRepository _orderItemRepository;
        public CreateOrderCommandHandler(IOrderRepository repository, IOrderItemRepository orderItemRepository)
        {
            _repository = repository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.UserId);
            var orderItem = new OrderItem(order.Id , request.Count , order.ProductId ,new Money(request.Price));
            _repository.Add(order);
            _orderItemRepository.Add(orderItem);
            await _repository.SaveChanges();
            return order.Id;
        }
    }
}
