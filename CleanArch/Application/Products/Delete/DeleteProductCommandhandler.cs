using Domain.Repositories;
using MediatR;
using Domain.Entities;
using Domain;

namespace Application.Command.Products.Delete;
public class DeleteProductCommandhandler : IRequestHandler<DeleteProductCommand, long>
{
    private readonly IProductRepository _repository;
    private readonly IDomainService _domainService;
    public DeleteProductCommandhandler(IProductRepository repository , IDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<long> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var Product = await _repository.GetById(request.ProductId);
        Product.Remove(request.ProductId, _domainService);
        _repository.Remove(Product);
        await _repository.SaveChanges();
        return Product.Id;
    }
}