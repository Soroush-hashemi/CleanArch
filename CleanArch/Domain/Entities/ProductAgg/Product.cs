using Domain.Base;
using Domain.Events;
using Domain.Exception;

namespace Domain.Entities
{
    public class Product : AggregateRoot
    {
        private IDomainService _orderDomainService;
        private Product(IDomainService orderDomainService)
        {
            _orderDomainService = orderDomainService;
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

        public void Garud(string title, Money price)
        {
            NullOrEmptyException.CheckString(title, "Title");
            NullOrEmptyException.CheckMoney(price, "Price");
        }

        public void Remove(string title, Money price, long ProductId)
        {
            _orderDomainService.IsProductExist(ProductId);
            Garud(title, price);
        }
    }
}
