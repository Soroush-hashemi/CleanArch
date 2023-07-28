using Domain;
using Domain.Repositories;

namespace Application;

public class OrderDomainService : IOrderDomainService
{
    private readonly IProductRepository _productRepository;

    public OrderDomainService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public bool IsProductExist(long ProductId)
    {
        var IsProductExist = _productRepository.IsProductExist(ProductId);

        return IsProductExist;
    }
}
