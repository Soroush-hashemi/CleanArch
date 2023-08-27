using ReadModel.Bases;
using ReadModel.ValueObject;

namespace ReadModel.Entities.ProductAgg
{
    public class ProductReadModel : BaseReadModel
    {
        public MoneyReadModel Price { get; private set; }
        public string Title { get; private set; }
        public ICollection<ProductImageReadModel> Images { get; private set; }
    }
}