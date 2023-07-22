using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Orders
{
    public class AddOrderDto
    {
        public Guid ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
