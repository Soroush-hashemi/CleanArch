using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Ef;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private AppDbContext _context;
        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(OrderItem orderItem)
        {
            _context.Add(orderItem);
        }

        public void Remove(OrderItem orderItem)
        {
            _context.Remove(orderItem);
        }

        public void Update(OrderItem orderItem)
        {
            _context.Update(orderItem);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public List<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public async Task<OrderItem> GetById(long id)
        {
            var result = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(result);
        }
    }
}
