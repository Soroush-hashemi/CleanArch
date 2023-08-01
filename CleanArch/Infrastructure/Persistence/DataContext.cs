using Domain.Entities;

namespace Infrastructure.Persistence
{
    // این کلاس پراپرتی های داره که در دامین درست شده اند 
    public class DataContext
    {
        // استاتیک ها نمونه نمیسازن از خود اطالاعات وارد شده استفاده میکنن 
        // ماهم اطالاعات داخل دامین رو میخوایم پس باید این کلاس استاتیک باشه 

        public List<Product> Products { get; set; } 
        public List<Order> Orders { get; set; }
    }
}
