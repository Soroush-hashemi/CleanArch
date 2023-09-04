using Domain.Entities.UserAgg.Events;
using Domain.Repositories;
using MediatR;
using ReadModel.Entities.UserAgg;
using ReadModel.Repositories;

namespace Application.Query.EventHandler.User
{
    public class UserEditedEventHandler : INotificationHandler<UserEdited>
    {
        private readonly IUserRepository _writeRepository;
        private readonly IUserReadRepository _readRepository;
        public UserEditedEventHandler(IUserRepository writeRepository, IUserReadRepository readRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(UserEdited notification, CancellationToken cancellationToken)
        {
            var User = await _writeRepository.GetById(notification.Id);
            await _readRepository.Update(new UserReadModel()
            {
                Name = User.Name,
                Family = User.Family,
                CreationDate = User.CreationDate,
                Id = notification.Id,
                Email = User.Email.EmailAddress
            });
        }

    }
}
