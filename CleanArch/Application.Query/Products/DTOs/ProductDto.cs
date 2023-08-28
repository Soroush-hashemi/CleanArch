using ReadModel.Entities.ProductAgg;
using ReadModel.ValueObject;

namespace Application.Query.Products.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public MoneyReadModel Price { get; set; }
        public string Title { get; set; }
        public ICollection<ProductImageReadModel> Images { get; set; }
    }
}
