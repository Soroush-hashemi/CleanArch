using Domain.Repositories;
using MediatR;
using Domain.Entities;
using Domain;
using Application.Command.Exceptions;
using Domain.Entities.ProductAgg.Events;

namespace Application.Command.Products.Delete;
public class DeleteProductCommandhandler : IRequestHandler<DeleteProductCommand, long>
{
    private readonly IProductRepository _repository;
    private readonly IProductExist _domainService;
    private readonly IMediator _mediator;
    public DeleteProductCommandhandler(IProductRepository repository, IProductExist domainService, IMediator mediator)
    {
        _repository = repository;
        _domainService = domainService;
        _mediator = mediator;

    }

    public async Task<long> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var Product = await _repository.GetById(request.ProductId);
        if (Product is null)
             ProductNotFoundException.Check();
        Product.Remove(request.ProductId, _domainService);
        _repository.Remove(Product);
        await _repository.SaveChanges();
        await _mediator.Publish(new ProductDeleted(Product.Id));
        return Product.Id;
    }
}