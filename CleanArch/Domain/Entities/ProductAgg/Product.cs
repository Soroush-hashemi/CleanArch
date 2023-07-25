using Domain.ValueObject.Sheard;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; } // نباید از بیرون این متغییر ها قابل تغییر باشن پس از پرایوت استفاده میکنم 
        public Money Price { get; private set; }
        public string Title { get; private set; }

        // پراپرتی های بالا به دلیل پرایوت بودن ست نمیشن و نال میمونن پی باید از این کانستراکتور استفاده بکنیم
        public Product(string title, Money price) 
        {
            Guard(title , price);
            Title = title;  
            Price = price;
            Id = Guid.NewGuid();
        } 

        public void Edit(string title, Money price)
        {
            Guard(title , price);
            Title = title;
            Price = price;
        }

        private void Guard(string title, Money price)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");

            if (price.Value < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
