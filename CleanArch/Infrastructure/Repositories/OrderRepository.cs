
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    // ریپازیتوری های داخل دامین اینجا ایمپلیمنت میشن 
    public class OrderRepository : IOrderRepository
    {
        private DataContext _datacontext;
        public OrderRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<Order> GetAll()
        {
            return _datacontext.Orders.ToList();
        }

        public Order GetById(Guid id)
        {
            return _datacontext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            _datacontext.Orders.Add(order);
        }

        public void Remove(Order order)
        {
            _datacontext.Orders.Remove(order);
        }

        public void Update(Order order)
        {
            var OldOrder = GetById(order.Id);
            Remove(OldOrder);
            Add(order);
        }
    }
}
