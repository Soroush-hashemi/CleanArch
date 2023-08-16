using Application.Query.Products.DTOs;
using MediatR;

namespace Application.Query.Products.GetList
{
    public record GetProductListQuery : IRequest<List<ProductDto>>;
}
