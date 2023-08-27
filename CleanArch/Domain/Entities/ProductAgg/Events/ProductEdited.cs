using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductAgg.Events
{
    public class ProductEdited : BaseDomainEvent
    {
        public string Title { get; set; }
        public long Id { get; set; }
        public ProductEdited(long id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
