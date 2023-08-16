using Application.Query.Products.DTOs;
using MediatR;

namespace Application.Query.Products.GetById
{
    public record GetProductByIdQuery(long ProductId) : IRequest<ProductDto>;
}
