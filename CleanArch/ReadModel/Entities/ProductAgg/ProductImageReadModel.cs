
namespace ReadModel.Entities.ProductAgg
{
    public class ProductImageReadModel
    {
        private ProductImageReadModel()
        {

        }
        public string ImageName { get; private set; }
        public long ProductId { get; private set; }

        public ProductImageReadModel(long productId, string imageName)
        {
            // NullOrEmptyException.CheckString(imageName, "ImageName");
            ProductId = productId;
            ImageName = imageName;
        }
    }
}
