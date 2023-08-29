using Domain.Entities.ProductAgg.Events;
using Domain.Repositories;
using MediatR;
using ReadModel.Entities.ProductAgg;
using ReadModel.Repositories;
using ReadModel.ValueObject;

namespace Application.Query.EventHandler.Product
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
    {
        private readonly IProductRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;
        public ProductCreatedEventHandler(IProductRepository writeRepository, IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.Id);
            var ReadProduct = (new ProductReadModel()
            {
                Id = product.Id,
                Images = null,
                Title = product.Title,
                Price = new MoneyReadModel(product.Price.Value),
                CreationDate = product.CreationDate
            });

            _readRepository.Insert(ReadProduct);
        }
    }
}
