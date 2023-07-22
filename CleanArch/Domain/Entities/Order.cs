namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public int TotalPrice => Count * Price;

        public Order(Guid productId, int count, int price)
        {
            Guard(productId, count, price);

            Id = Guid.NewGuid();
            ProductId = productId;
            Price = price;
            Count = count;
        }

        public void IncreaseProductCount(int count)
        {
            GuardCount(count);
            count =+ Count;
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
        }

        private void Guard(Guid productId, int count, int price)
        {
            if (productId == Guid.Empty)
                throw new ArgumentOutOfRangeException();

            if (price < 0)
                throw new ArgumentOutOfRangeException();

            GuardCount(count);
        }

        private void GuardCount(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
