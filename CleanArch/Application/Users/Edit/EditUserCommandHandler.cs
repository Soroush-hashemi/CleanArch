using Application.Command.Exceptions;
using Domain;
using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Users.Edit;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand, long>
{
    private readonly IUserRepository _repository;
    public EditUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.UserId);
        if (user is null)
            UserNotFoundException.Check();
        user.Edit(request.Name, request.Family, new Email(request.Email));
        _repository.Update(user);
        await _repository.SaveChanges();
    //  event
        return user.Id;
    }
}