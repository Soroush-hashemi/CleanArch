using Application.Query.Products.DTOs;
using Domain.Entities;

namespace Application.Query.Products.Mapper
{
    public class ProductMapper
    {
        public static ProductDto MapProductToDto(Product product)
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
