using Domain.Base;

namespace Domain.Exception
{
    public class UserNotFoundException : BaseDomainException
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
