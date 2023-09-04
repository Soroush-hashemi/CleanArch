using Domain.Base;
using Domain;

namespace WebApi.ViewModels.Products
{
    public class ProductViewModel // یوزر این پراپرتی هارو پر میکنه و ما میدیمش به دی تی او پروداکت در کوئری
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Money Money { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
