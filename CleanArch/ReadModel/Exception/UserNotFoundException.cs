using ReadModel.Bases;

namespace Domain.Exception
{
    public class UserNotFoundException : BaseReadModelException
    {
        public UserNotFoundException()
        {
            
        }

        public static void Check()
        {
            throw new NotImplementedException("user not exist");
        }
    }
}
