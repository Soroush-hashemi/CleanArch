using Domain.ValueObject.Sheard;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public ICollection<OrderItem> Items { get; set; }

        public int TotalPrice { get; private set; }

        public Order(Guid productId)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
        }

        public void AddItem(Guid ProductId, int Count, int Price, IOrderDomainService OrderDomainService)
        {
            if (OrderDomainService.IsProductExist(ProductId) == false)
                throw new ArgumentException("Product is Exist");

            Items.Add(new OrderItem(Id, Count, ProductId, Money.FromTooman(Price)));
            TotalPrice += Count;
        }

        public void RemoveItem(Guid ProductId)
        {
            var item = Items.FirstOrDefault(p => p.ProductId == p.ProductId);
            if (item != null)
                throw new Exception("Is null!");

            Items.Remove(item);
            TotalPrice -= item.Count;
        }
    }
}
