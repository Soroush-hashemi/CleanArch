

namespace Application.Command.Exceptions
{
    public class ProductNotFoundException
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
