using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class BaseApplicationException : Exception
    {
        public BaseApplicationException()
        {
            
        }

        public BaseApplicationException(string message) : base(message)
        {
            
        }
    }
}
