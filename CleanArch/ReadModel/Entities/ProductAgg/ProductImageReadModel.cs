
namespace ReadModel.Entities.ProductAgg
{
    public class ProductImageReadModel
    {
        public string ImageName { get; set; }
        public long ProductId { get; set; }

        public ProductImageReadModel(long productId, string imageName)
        {

        }
    }
}
