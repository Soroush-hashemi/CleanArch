using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    // ریپازیتوری های داخل دامین اینجا ایمپلیمنت میشن 
    public class OrderRepository : IOrderRepository
    {
        private DataContext _context;
        public OrderRepository(DataContext datacontext)
        {
            _context = datacontext;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }

        public void Update(Order order)
        {
            // _datacontext.Update(order);
        }

        public async Task<Order> GetById(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
