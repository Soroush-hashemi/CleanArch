using Domain;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _repository;
        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var User = new User(request.Name, request.Family, new Email(request.Email));
            _repository.Add(User);
            await _repository.SaveChanges();
            return User.Id;
        }
    }
}
