using Application.Query.Products.Mapper;
using Domain.Entities.ProductAgg.Events;
using Domain.Repositories;
using MediatR;
using ReadModel.Entities.ProductAgg;
using ReadModel.Repositories;

namespace Application.Query.EventHandler.Product;
public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
{   // هر زمان داخل اپلیکشن کامند یک ایونت هندلر درست بشه و بعد از پابلیش اون ایونت برنامه ی ما میاد اینجا و اینجا رو اجرا میکنه
    private readonly IProductRepository _writeRepository;
    private readonly IProductReadRepository _readRepository;
    public ProductCreatedEventHandler(IProductRepository writeRepository, IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(ProductCreated notification, CancellationToken cancellationToken) 
    {   // اطلاعات ساخته شده در کامند میاریم اینجا و داخل مونگو سیو میکنیم
        var product = await _writeRepository.GetById(notification.Id);
        var ReadProduct = (new ProductReadModel()
        {
            Id = product.Id,
            Images = product.Images?.Select(ImageMapper.FromProductImage).ToList(),
            Title = product.Title,
            Price = MoneyMapper.FromMoney(product.Price),
            CreationDate = product.CreationDate
        });

        _readRepository.Insert(ReadProduct);
    }
}