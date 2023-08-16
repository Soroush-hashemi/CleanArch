using Domain;
using MediatR;

namespace Application.Command.Orders.Create
{
    public class CreateOrderCommand : IRequest<long>
    {
        public CreateOrderCommand(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; set; }
    }
}
