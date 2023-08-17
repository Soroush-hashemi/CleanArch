using Application.Query.Products.DTOs;
using Application.Query.Products.Mapper;
using Infrastructure.Persistence.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly AppDbContext _context;
        public GetProductByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);
            return ProductMapper.MapProductToDto(Product);
        }
    }
}
