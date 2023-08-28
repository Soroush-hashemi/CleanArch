using Application.Query.Products.DTOs;
using Application.Query.Products.Mapper;
using MediatR;
using ReadModel.Repositories;

namespace Application.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductReadRepository _readRepository;

        public GetProductByIdQueryHandler(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request /* اینجا اطلاعاتی که یوزر فرستاده رو داریم */, CancellationToken cancellationToken)
        {
            var Product = await _readRepository.GetById(request.ProductId); // اینجا دیتا از جنس رید مدل رو میگیره و 
            return ProductMapper.MapProductToDto(Product); // اینجا دیتا رو به دی تی او مپ میکنه و بعد ریترن 
        }
    }
}
