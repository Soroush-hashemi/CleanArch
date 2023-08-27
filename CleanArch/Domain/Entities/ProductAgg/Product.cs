using Domain.Base;
using Domain.Entities.ProductAgg.Events;
using Domain.Exception;

namespace Domain.Entities
{
    public class Product : AggregateRoot
    {
        private Product()
        {

        }
        // نباید از بیرون این متغییر ها قابل تغییر باشن پس از پرایوت استفاده میکنم 
        public Money Price { get; private set; }
        public string Title { get; private set; }
        public ICollection<ProductImage> Images { get; private set; }

        // پراپرتی های بالا به دلیل پرایوت بودن ست نمیشن و نال میمونن پس باید از این کانستراکتور استفاده بکنیم
        public Product(string title, Money price)
        {
            Garud(title, price);
            Title = title;
            Price = price;
            Images = new List<ProductImage>();
            AddDomainEvent(new ProductCreated(Id, $"{title}"));
        }

        public void Edit(string title, Money price)
        {
            Garud(title, price);
            Title = title;
            Price = price;
            AddDomainEvent(new ProductEdited(Id, $"{title}"));
        }

        public void AddImage(string ImageName)
        {
            NullOrEmptyException.CheckString(ImageName, "ImageName");
            Images.Add(new ProductImage(Id, ImageName));
        }

        public void RemoveImage(long Id)
        {
            var image = Images.FirstOrDefault(i => i.Id == Id);
            NullOrEmptyException.CheckObject(image);
            Images.Remove(image);
        }

        public void Remove(long ProductId, IProductExist domainService) // متد اینجکشن
        {
            if (domainService.IsProductExist(ProductId) == false)
                ProductNotFoundException.Check();
        }

        public void Garud(string title, Money price)
        {
            NullOrEmptyException.CheckString(title, "Title");
            NullOrEmptyException.CheckMoney(price, "Price");
        }
    }
}
