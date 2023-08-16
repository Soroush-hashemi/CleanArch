using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Ef;

namespace Infrastructure.Repositories
{
    // ریپازیتوری های داخل دامین اینجا ایمپلیمنت میشن 
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
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
            _context.Update(order);
        }

        public async Task<Order> GetById(long id)
        {
            var result = _context.Orders.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(result);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
