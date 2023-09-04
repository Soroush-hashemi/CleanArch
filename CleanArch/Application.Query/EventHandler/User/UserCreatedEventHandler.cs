using Application.Query.Products.Mapper;
using Domain;
using Domain.Entities.ProductAgg.Events;
using Domain.Entities.UserAgg.Events;
using Domain.Repositories;
using MediatR;
using ReadModel.Entities.ProductAgg;
using ReadModel.Entities.UserAgg;
using ReadModel.Repositories;

namespace Application.Query.EventHandler.User;

public class UserCreatedEventHandler : INotificationHandler<UserRegistered>
{   
    private readonly IUserRepository _writeRepository;
    private readonly IUserReadRepository _readRepository;
    public UserCreatedEventHandler(IUserRepository writeRepository, IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
    {
        var User = await _writeRepository.GetById(notification.Id);
        var ReadUser = (new UserReadModel()
        {
            Name = User.Name,
            Family = User.Family,
            CreationDate = User.CreationDate,
            Id = notification.Id,
            Email = User.Email.EmailAddress
        });

        _readRepository.Insert(ReadUser);
    }
}