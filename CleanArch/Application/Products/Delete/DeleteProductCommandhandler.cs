using Domain.Repositories;
using MediatR;
using Domain.Entities;

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
        bool IsProductExist = _repository.IsProductExist(request.ProductId);

        if (IsProductExist is false)
            throw new Exception();
            
        Product.Remove(request.ProductId);
        _repository.Remove(Product);
        await _repository.SaveChanges();
        return Product.Id;
    }
}