using Application.Query.Products.DTOs;
using Application.Query.Products.Mapper;
using MediatR;
using ReadModel.Repositories;

namespace Application.Query.Products.GetList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly IProductReadRepository _readRepository;
        public GetProductListQueryHandler(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _readRepository.GetAll();
            var productDtos = products.Select(product => ProductMapper.MapProductToDto(product)).ToList();
            return productDtos;
        }
    }
}