using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exception
{
    public class UserNotFoundException
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
