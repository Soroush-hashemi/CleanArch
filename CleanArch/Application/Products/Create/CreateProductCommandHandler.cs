using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Title, Money.FromRial(request.Price));
            _repository.Add(product);
            _repository.SaveChanges();

            return await Unit.Task;
        }
    }
}
