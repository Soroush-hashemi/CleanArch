using Domain.Base;
using Domain.Entities.OrderAgg.Events;
using Domain.Exception;
using Domain.Service;

namespace Domain.Entities
{
    public class Order : AggregateRoot
    {
        private Order()
        {

        }
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public ICollection<OrderItem> Items { get; set; }
        public int TotalItem { get; set; }
        public int TotalPrice => Items.Sum(r => r.Price.Value);


        public Order(long userId, IUserExist domainService)
        {
            if (domainService.IsUserExsit(userId) is false)
                UserNotFoundException.Check();
            UserId = userId;
            Items = new List<OrderItem>();
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            AddDomainEvent(new OrderFinalized(Id, UserId));
        }

        public void AddItem(long ProductId, int Count, int Price, IProductExist OrderDomainService) // متد انجکشن
        {
            if (OrderDomainService.IsProductExist(ProductId) is false) // یعنی زمانی که پروداکت وجود ندارد 
                ProductNotFoundException.Check();

            Items.Add(new OrderItem(Id, Count, ProductId, Money.FromTooman(Price)));
            TotalItem += Count;
        }

        public void RemoveItem(long ProductId)
        {
            var item = Items.FirstOrDefault(p => p.ProductId == ProductId);

            NullOrEmptyException.CheckObject(item);

            Items.Remove(item);
            TotalItem -= item.Count;
        }
    }
}
