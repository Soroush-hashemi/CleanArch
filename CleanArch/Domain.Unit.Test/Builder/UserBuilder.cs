using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Unit.Test.Builder
{
    public class UserBuilder
    {
        public User CreateUser(string name, string family, string email)
        {
            var user = new User(name, family, new Email(email));

            return user;
        }
    }
}
