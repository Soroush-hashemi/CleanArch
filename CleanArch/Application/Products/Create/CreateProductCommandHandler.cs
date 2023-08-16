using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _repository;
        private readonly CreateProductCommandValidator _validations;
        public CreateProductCommandHandler(IProductRepository repository, CreateProductCommandValidator validations)
        {
            _repository = repository;
            _validations = validations;

        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var ValidatorChecker = _validations.Validate(request);
            if (!ValidatorChecker.IsValid)
                throw new InvalidDataException(ValidatorChecker.Errors.ToString());

            var product = new Product(request.Title, Money.FromRial(request.Price));
            _repository.Add(product);
            await _repository.SaveChanges();
            return product.Id;
        }
    }

}
