using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderItemRepository
    {
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Remove(OrderItem orderItem);
        List<OrderItem> GetAll();
        Task<OrderItem> GetById(long id);
        Task SaveChanges();
    }
}
