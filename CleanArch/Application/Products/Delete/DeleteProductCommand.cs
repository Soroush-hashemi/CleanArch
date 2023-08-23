using Domain.Base;
using MediatR;

namespace Application.Command.Products.Delete;
public class DeleteProductCommand : IRequest<long>
{
    public DeleteProductCommand(long productId, string title, Money price)
    {
        Title = title;
        Price = price;
        ProductId = productId;
    }

    public string Title { get; set; }
    public long ProductId { get; set; }
    public Money Price { get; set; }
}