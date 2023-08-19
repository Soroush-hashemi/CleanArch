using Domain.Base;
using MediatR;
using System.Diagnostics;

namespace Application.Command.Orders.Create
{
    public class CreateOrderCommand : IRequest<long>
    {
        public CreateOrderCommand(long userId,Money price , int count)
        {
            UserId = userId;
            Price = price;
            Count = count;
        }

        public long UserId { get; set; }
        public Money Price { get; set; }
        public int Count { get; set; }
    }
}
