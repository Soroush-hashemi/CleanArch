using MediatR;

namespace Application.Command.Users.Edit;

public class EditUserCommand : IRequest<long>
{
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Family { get; set; }
}