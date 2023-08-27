using ReadModel.Bases;

namespace Domain.Exception
{
    public class ProductNotFoundException : BaseReadModelException
    {
        public ProductNotFoundException()
        {

        }

        public static void Check()
        {
            throw new NotImplementedException("product not exist");
        }
    }
}
