using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Update(Order order);
        void Remove(Order order);
        List<Order> GetAll();
        Task<Order> GetById(long id);
        Task SaveChanges(); //  در شرایط استفاده از ترانسلکشن ها باید اینو اینجا بسازیم
    } 
}
