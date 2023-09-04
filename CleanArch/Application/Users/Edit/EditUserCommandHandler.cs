using Application.Command.Exceptions;
using Domain;
using Domain.Entities.UserAgg.Events;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Users.Edit;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand, long>
{
    private readonly IUserRepository _repository;
    private readonly IMediator _mediator;
    public EditUserCommandHandler(IUserRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<long> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.UserId);
        if (user is null)
            UserNotFoundException.Check();
        user.Edit(request.Name, request.Family, new Email(request.Email));
        _repository.Update(user);
        await _repository.SaveChanges();
        await _mediator.Publish(new UserEdited(user.Id, user.Email));
        return user.Id;
    }
}