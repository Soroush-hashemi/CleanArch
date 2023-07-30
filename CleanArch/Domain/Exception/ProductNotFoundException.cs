using Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exception
{
    public class ProductNotFoundException : BaseDomainException
    {
        public ProductNotFoundException()
        {
            
        }

        public static void Check()
        {

        }
    }
}
