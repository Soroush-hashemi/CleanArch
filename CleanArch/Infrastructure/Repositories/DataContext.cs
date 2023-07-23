using Domain.Entities;
using Domain.ValueObject.Sheard;

namespace Infrastructure.Repositories
{
    // این کلاس پراپرتی های داره که در دامین درست شده اند 
    public class DataContext
    {
        // استاتیک ها نمونه نمیسازن از خود اطالاعات وارد شده استفاده میکنن 
        // ماهم اطالاعات داخل دامین رو میخوایم پس باید این کلاس استاتیک باشه 

        public List<Product> Products { get; set; } = new List<Product>() { new Product("chips", new Money(12000)) };
        public List<Order> Orders { get; set; } = new List<Order>() { new Order(Guid.NewGuid(), 1,new Money(12000)) };
    }
}
