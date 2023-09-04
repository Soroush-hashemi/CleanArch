

using Domain.Entities.ProductAgg.Events;
using Domain.Repositories;
using MediatR;
using ReadModel.Repositories;

namespace Application.Query.EventHandler.Product;
public class ProductDeletedEventHandler : INotificationHandler<ProductDeleted>
{
    private readonly IProductReadRepository _readRepository;
    public ProductDeletedEventHandler(IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task Handle(ProductDeleted notification, CancellationToken cancellationToken)
    {
        await _readRepository.Delete(notification.Id);
    }
}