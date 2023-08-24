using Domain.Base;
using MediatR;
using System.Diagnostics;

namespace Application.Command.Orders.Create
{
    public class CreateOrderCommand : IRequest<long>
    {
        public CreateOrderCommand(long userId, int price, int count)
        {
            UserId = userId;
            Price = price;
            Count = count;
        }

        public long UserId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
