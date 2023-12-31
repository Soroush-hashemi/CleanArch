﻿using Domain;
using Domain.Repositories;
using MediatR;
using Domain.Entities.UserAgg.Events;

namespace Application.Command.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _repository;
        private readonly IMediator _mediator;
        public CreateUserCommandHandler(IUserRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;

        }
        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var User = new User(request.Name, request.Family, new Email(request.Email));
            User.Register(request.Name, request.Family, new Email(request.Email));
            _repository.Add(User);
            await _repository.SaveChanges();
            await _mediator.Publish(new UserRegistered(User.Id,User.Email));
            return User.Id;
        }
    }
}
