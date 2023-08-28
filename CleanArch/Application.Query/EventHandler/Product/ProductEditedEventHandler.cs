using Domain.Entities.ProductAgg.Events;
using Domain.Repositories;
using MediatR;
using ReadModel.Entities.ProductAgg;
using ReadModel.Repositories;
using ReadModel.ValueObject;
using System;

namespace Application.Query.EventHandler.Product;

public class ProductEditedEventHandler : INotificationHandler<ProductEdited>
{
    private readonly IProductRepository _writeRepository;
    private readonly IProductReadRepository _readRepository;
    public ProductEditedEventHandler(IProductRepository writeRepository, IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(ProductEdited notification, CancellationToken cancellationToken)
    {
        var product = await _writeRepository.GetById(notification.Id);
        await _readRepository.Insert(new ProductReadModel()
        {
            Id = notification.Id,
            Title = product.Title,
            Price = new MoneyReadModel(product.Price.Value),
            Images = null,
            CreationDate = notification.CreationDate,
        });
    }
}