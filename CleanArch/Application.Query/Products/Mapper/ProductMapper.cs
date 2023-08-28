using Application.Query.Products.DTOs;
using Domain.Entities;
using ReadModel.Entities.ProductAgg;

namespace Application.Query.Products.Mapper
{
    public class ProductMapper
    {
        public static ProductDto MapProductToDto(ProductReadModel product)
        {
            if (product == null)
                throw new ArgumentNullException();

            return new ProductDto()
            {
                Price = product.Price,
                Images = product.Images,
                Id = product.Id,
                Title = product.Title,
            };
        }
    }
}
