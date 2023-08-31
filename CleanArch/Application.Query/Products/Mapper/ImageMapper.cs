
using Application.Query.Products.DTOs;
using Domain;
using Domain.Entities;
using ReadModel.Entities.ProductAgg;

namespace Application.Query.Products.Mapper
{
    public class ImageMapper
    {
        public static ProductImageReadModel FromProductImage(ProductImage productImage)
        {
            return new ProductImageReadModel(productImage.ProductId, productImage.ImageName);
        }
    }

}
