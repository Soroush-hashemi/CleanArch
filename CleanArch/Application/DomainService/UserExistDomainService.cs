using Domain.Entities;
using Domain.Repositories;
using Domain.Service;

namespace Application.Command.DomainService;
public class UserExistDomainService : IUserExist
{
    private readonly IUserRepository _repository;
    public UserExistDomainService(IUserRepository repository)
    {
        _repository = repository;   
    }

    public bool IsUserExsit(long UserId)
    {
        var User = _repository.IsUserExist(UserId);
        if (User is false)
            return false;
        else
            return true;
    }
}
