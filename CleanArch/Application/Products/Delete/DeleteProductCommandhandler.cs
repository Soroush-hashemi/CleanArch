using Domain.Repositories;
using MediatR;
using Domain.Entities;
using Domain;

namespace Application.Command.Products.Delete;
public class DeleteProductCommandhandler : IRequestHandler<DeleteProductCommand, long>
{
    private readonly IProductRepository _repository;
    public DeleteProductCommandhandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var Product = await _repository.GetById(request.ProductId);
        Product.Remove(request.Title, request.Price, request.ProductId);

    }
}