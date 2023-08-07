using Domain.Base;
using Domain.Exception;

namespace Domain.Entities
{
    public class Order : AggregateRoot
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public ICollection<OrderItem> Items { get; set; }
        public int TotalItem { get; private set; }

        public Order(long userId)
        {
            UserId = userId;
            Items = new List<OrderItem>();
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            AddDomainEvent(new OrderFinalized(Id, UserId));
        }

        public void AddItem(long ProductId, int Count, int Price, IOrderDomainService OrderDomainService) // متد انجکشن
        {
            if (OrderDomainService.IsProductExist(ProductId) == false)
                ProductNotFoundException.Check();

            Items.Add(new OrderItem(Id, Count, ProductId, Money.FromTooman(Price)));
            TotalItem += Count;
        }

        public void RemoveItem(long ProductId)
        {
            var item = Items.FirstOrDefault(p => p.ProductId == ProductId);

            //if (item == null)
                NullOrEmptyException.CheckObject(item);

            Items.Remove(item);
            TotalItem -= item.Count;
        }
    }
}
