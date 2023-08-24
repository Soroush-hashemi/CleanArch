using Domain;
using Domain.Repositories;

namespace Application.Command.DomainService;
public class ProductExistDomainService : IProductExist
{
    private readonly IProductRepository _repository;
    public ProductExistDomainService(IProductRepository repository)
    {
        _repository = repository;
    }
    public bool IsProductExist(long ProductId)
    {
        bool product = _repository.IsProductExist(ProductId);
        if (product is false)
            return false;
        else
            return true;
    }
}