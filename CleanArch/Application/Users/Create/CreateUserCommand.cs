using Domain;
using MediatR;

namespace Application.Command.Users.Create
{
    public class CreateUserCommand : IRequest<long>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Family { get; private set; }

        public CreateUserCommand(string name, string family, string email)
        {
            Name = name;
            Family = family;
            Email = email;
        }
    }
}
