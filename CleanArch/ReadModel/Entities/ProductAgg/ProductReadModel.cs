using ReadModel.Exception;
using ReadModel.Bases;
using ReadModel.ValueObject;

namespace ReadModel.Entities.ProductAgg
{
    public class ProductReadModel : BaseReadModel
    {
        public MoneyReadModel Price { get; set; }
        public string Title { get; set; }
        public ICollection<ProductImageReadModel> ?Images { get; set; }

        public ProductReadModel()
        {

        }

        public void Garud(string title, MoneyReadModel price)
        {
            NullOrEmptyException.CheckString(title, "Title");
            NullOrEmptyException.CheckMoney(price, "Price");
        }
    }
}