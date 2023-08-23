using Domain.Base;
using MediatR;

namespace Application.Command.Products.Delete;
public class DeleteProductCommand : IRequest<long>
{
    public DeleteProductCommand(long productId)
    {
        ProductId = productId;
    }

    public long ProductId { get; set; }
}