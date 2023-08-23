using Domain;
using Domain.Repositories;

namespace Application.Command.DomainService;
public class DomainService : IDomainService
{
    private readonly IProductRepository _repository;
    public DomainService(IProductRepository repository)
    {
        _repository = repository;
    }
    public bool IsProductExist(long ProductId)
    {
        var product = _repository.GetById(ProductId);
        if (product is null)
            return false;
        else 
            return true;
    }
}
