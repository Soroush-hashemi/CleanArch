using Domain.Base;
using Domain.Entities;
using Domain.Entities.ProductAgg.Events;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        public CreateProductCommandHandler(IProductRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Title, Money.FromRial(request.Price));
            _repository.Add(product);
            await _repository.SaveChanges();
            await _mediator.Publish(new ProductCreated(product.Id, product.Title));
            return product.Id;
        }
    }
}
