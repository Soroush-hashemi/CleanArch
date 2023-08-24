using MediatR;

namespace Application.Command.Users.Edit;

public class EditUserCommand : IRequest<long>
{
    public long UserId { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Family { get; private set; }
}