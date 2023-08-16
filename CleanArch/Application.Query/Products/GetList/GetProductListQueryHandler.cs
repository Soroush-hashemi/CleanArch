using Application.Query.Products.DTOs;
using Application.Query.Products.Mapper;
using Infrastructure.Persistence.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query.Products.GetList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly AppDbContext _context;
        public GetProductListQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Include(i => i.Images).Select(product => ProductMapper.MapProductToDto(product)).ToListAsync();
        }
    }
}
