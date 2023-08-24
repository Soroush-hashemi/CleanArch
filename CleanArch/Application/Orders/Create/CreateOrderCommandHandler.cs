using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using Domain.Service;
using MediatR;

namespace Application.Command.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IUserExist _domainService;
        public CreateOrderCommandHandler(IOrderRepository repository, IOrderItemRepository orderItemRepository, IUserExist domainService)
        {
            _repository = repository;
            _orderItemRepository = orderItemRepository;
            _domainService = domainService;
        }

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.UserId, _domainService);
            var orderItem = new OrderItem(order.Id, request.Count, order.ProductId, new Money(request.Price));
            _repository.Add(order);
            _orderItemRepository.Add(orderItem);
            await _orderItemRepository.SaveChanges();
            await _repository.SaveChanges();
            return order.Id;
        }
    }
}
