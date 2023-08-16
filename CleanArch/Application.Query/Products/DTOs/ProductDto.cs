using Domain.Base;
using Domain;

namespace Application.Query.Products.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public Money Price { get; set; }
        public string Title { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
