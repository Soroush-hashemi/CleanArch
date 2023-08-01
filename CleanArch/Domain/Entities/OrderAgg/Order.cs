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

        public int TotalPrice { get; private set; }

        public Order(long userId)
        {
            UserId = userId;
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            AddDomainEvent(new OrderFinalized(Id, UserId));
        }

        public void AddItem(long ProductId, int Count, int Price, IOrderDomainService OrderDomainService)
        {
            if (OrderDomainService.IsProductExist(ProductId) == false)
                ProductNotFoundException.Check();

            Items.Add(new OrderItem(Id, Count, ProductId, Money.FromTooman(Price)));
            TotalPrice += Count;
        }

        public void RemoveItem(long ProductId)
        {
            var item = Items.FirstOrDefault(p => p.ProductId == ProductId);
            NullOrEmptyException.CheckObject(item,"OrderItem");
            Items.Remove(item);
            TotalPrice -= item.Count;
        }
    }
}
