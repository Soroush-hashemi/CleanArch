using Domain.Base;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Products.Edit
{
    public class EditProductCommandhandler : IRequestHandler<EditProductCommand, long>
    {
        private readonly IProductRepository _repository;
        public EditProductCommandhandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<long> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);
            product.Edit(request.Title, Money.FromRial(1000));
            _repository.Update(product);
            await _repository.SaveChanges();
            return product.Id;
        }
    }
}